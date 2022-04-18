using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace System.Web.Adapters.SessionState;

internal class RemoteSessionState : ISessionState
{
    private readonly RemoteSessionService _remoteSessionService;
    private readonly RemoteAppSessionStateOptions _options;
    private readonly ILogger<RemoteSessionState> _logger;

    private readonly RemoteSessionDataResponse _remoteDataResponse;

    private RemoteSessionData RemoteData => _remoteDataResponse.RemoteSessionData;

    private RemoteSessionState(RemoteSessionDataResponse remoteDataResponse, RemoteSessionService remoteSessionService, RemoteAppSessionStateOptions options, ILogger<RemoteSessionState> logger)
    {
        _remoteDataResponse = remoteDataResponse ?? throw new ArgumentNullException(nameof(remoteDataResponse));
        _remoteSessionService = remoteSessionService ?? throw new ArgumentNullException(nameof(remoteSessionService));
        _options = options ?? throw new ArgumentNullException(nameof(options));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public static async Task<RemoteSessionState> CreateAsync(HttpContextCore context,
                                                      bool readOnly,
                                                      RemoteSessionService remoteSessionService,
                                                      RemoteAppSessionStateOptions options,
                                                      ILogger<RemoteSessionState> logger,
                                                      CancellationToken cancellationToken = default)
    {
        using var timeout = new CancellationTokenSource(options.NetworkTimeout);
        using var cts = CancellationTokenSource.CreateLinkedTokenSource(timeout.Token, context.RequestAborted, cancellationToken);

        // If an existing remote session ID is present in the request, use its session ID.
        // Otherwise, leave session ID null for now; it will be provided by the remote service
        // when session data is loaded.
        var sessionId = context.Request.Cookies[options.CookieName];

        try
        {
            // Get or create session data
            var response = await remoteSessionService.GetSessionDataAsync(sessionId, readOnly, context, cts.Token);
            logger.LogDebug("Loaded {SessionItemCount} items from remote session state for session {SessionId}", response.RemoteSessionData.Values.Count, sessionId);

            return new RemoteSessionState(response, remoteSessionService, options, logger);
        }
        catch (Exception exc)
        {
            logger.LogError(exc, "Unable to load remote session state for session {SessionId}", sessionId);
            throw;
        }
    }

    public async ValueTask CommitAsync(CancellationToken cancellationToken = default)
    {
        if (RemoteData.IsReadOnly)
        {
            _logger.LogDebug("Skipping commit for read-only session");
            return;
        }

        using var timeout = new CancellationTokenSource(_options.NetworkTimeout);
        using var cts = CancellationTokenSource.CreateLinkedTokenSource(timeout.Token, cancellationToken);

        var sessionId = RemoteData.SessionID;

        try
        {
            await _remoteSessionService.SetOrReleaseSessionData(sessionId, RemoteData, cts.Token);
            _logger.LogDebug("Set items and released lock for session {SessionId}", sessionId);
        }
        catch (Exception exc)
        {
            _logger.LogError(exc, "Unable to commit remote session state for session {SessionKey}", sessionId);
            throw;
        }
        finally
        {
            _remoteDataResponse.Dispose();
        }
    }

    public string SessionID => RemoteData.SessionID;

    public object? this[string key]
    {
        get => RemoteData.Values[key];
        set => RemoteData.Values[key] = value;
    }

    public int Timeout
    {
        get => RemoteData.Timeout;
        set => RemoteData.Timeout = value;
    }

    public bool IsNewSession => RemoteData.IsNewSession;

    public IEnumerable<string> Keys => RemoteData.Values.Keys;

    public int Count => RemoteData.Values.Count;

    public bool IsReadOnly => RemoteData.IsReadOnly;

    public bool IsSynchronized => false;

    public object SyncRoot => this;

    public void Abandon() => RemoteData.Abandon = true;

    public void Add(string key, object? value) => RemoteData.Values[key] = value;

    public void Add(KeyValuePair<string, object?> item) => Add(item.Key, item.Value);

    public void Clear() => RemoteData.Values.Clear();

    public bool Contains(KeyValuePair<string, object?> item) => ContainsKey(item.Key) && (this[item.Key]?.Equals(item.Value) ?? item.Value is null);

    public bool ContainsKey(string key) => RemoteData.Values.Keys.Cast<string>().Contains(key);

    public IEnumerator GetEnumerator() => RemoteData.Values.GetEnumerator();

    public void Remove(string key) => RemoteData.Values.Remove(key);

    public bool Remove(KeyValuePair<string, object?> item)
    {
        if (Contains(item))
        {
            Remove(item.Key);
            return true;
        }

        return false;
    }

    public bool TryGetValue(string key, out object? value)
    {
        if (ContainsKey(key))
        {
            value = this[key];
            return true;
        }
        else
        {
            value = null;
            return false;
        }
    }

    public void CopyTo(Array array, int index) => ((ICollection)RemoteData.Values).CopyTo(array, index);

    public void Dispose()
    {
        _remoteDataResponse?.Dispose();
    }
}
