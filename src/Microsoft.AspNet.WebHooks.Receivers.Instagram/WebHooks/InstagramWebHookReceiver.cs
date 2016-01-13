﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using Microsoft.AspNet.WebHooks.Properties;
using Newtonsoft.Json.Linq;

namespace Microsoft.AspNet.WebHooks
{
    /// <summary>
    /// Provides an <see cref="IWebHookReceiver"/> implementation which supports WebHooks generated by Instagram. 
    /// Set the '<c>MS_WebHookReceiverSecret_Instagram</c>' application setting to the application secrets, optionally using IDs
    /// to differentiate between multiple WebHooks, for example '<c>secret0, id1=secret1, id2=secret2</c>'.
    /// The corresponding WebHook URI is of the form '<c>https://&lt;host&gt;/api/webhooks/incoming/instagram/{id}</c>'.
    /// For details about Instagram WebHooks, see <c>https://instagram.com/developer/realtime/</c>.
    /// </summary>
    public class InstagramWebHookReceiver : WebHookReceiver
    {
        internal const string RecName = "instagram";
        internal const int SecretMinLength = 32;
        internal const int SecretMaxLength = 128;

        internal const string SignatureHeaderName = "x-hub-signature";
        internal const string ChallengeParameter = "hub.challenge";
        internal const string ActionKey = "object";

        /// <summary>
        /// Gets the receiver name for this receiver.
        /// </summary>
        public static string ReceiverName
        {
            get { return RecName; }
        }

        /// <inheritdoc />
        public override string Name
        {
            get { return RecName; }
        }

        /// <inheritdoc />
        public override async Task<HttpResponseMessage> ReceiveAsync(string id, HttpRequestContext context, HttpRequestMessage request)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            if (request.Method == HttpMethod.Post)
            {
                EnsureSecureConnection(request);

                bool valid = await VerifySignature(id, request);
                if (!valid)
                {
                    return CreateBadSignatureResponse(request, SignatureHeaderName);
                }

                // Read the request entity body
                JArray data = await ReadAsJsonArrayAsync(request);

                // Get the event actions
                IEnumerable<string> actions = GetActions(data, request);

                // Call registered handlers
                return await ExecuteWebHookAsync(id, context, request, actions, data);
            }
            else if (request.Method == HttpMethod.Get)
            {
                return await WebHookVerification(id, request);
            }
            else
            {
                return CreateBadMethodResponse(request);
            }
        }

        /// <summary>
        /// Verifies that the signature header matches that of the actual body.
        /// </summary>
        protected virtual async Task<bool> VerifySignature(string id, HttpRequestMessage request)
        {
            string secretKey = await GetReceiverConfig(request, Name, id, SecretMinLength, SecretMaxLength);

            // Get the expected hash from the signature header
            string signatureHeaderValue = GetRequestHeader(request, SignatureHeaderName);

            byte[] expectedHash;
            try
            {
                expectedHash = EncodingUtilities.FromHex(signatureHeaderValue);
            }
            catch (Exception ex)
            {
                string msg = string.Format(CultureInfo.CurrentCulture, InstagramReceiverResources.Receiver_BadHeaderEncoding, SignatureHeaderName);
                request.GetConfiguration().DependencyResolver.GetLogger().Error(msg, ex);
                HttpResponseMessage invalidEncoding = request.CreateErrorResponse(HttpStatusCode.BadRequest, msg);
                throw new HttpResponseException(invalidEncoding);
            }

            // Get the actual hash of the request body concatenated with the request URI
            byte[] actualHash;
            byte[] secret = Encoding.UTF8.GetBytes(secretKey);
            using (var hasher = new HMACSHA1(secret))
            {
                byte[] data = await request.Content.ReadAsByteArrayAsync();
                actualHash = hasher.ComputeHash(data);
            }

            // Now verify that the provided hash matches the expected hash.
            return WebHookReceiver.SecretEqual(expectedHash, actualHash);
        }

        /// <summary>
        /// Creates a response to a WebHook verification GET request.
        /// </summary>
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Disposed by caller")]
        protected virtual async Task<HttpResponseMessage> WebHookVerification(string id, HttpRequestMessage request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            EnsureSecureConnection(request);

            // Verify that we have the secret as an app setting
            await GetReceiverConfig(request, Name, id, SecretMinLength, SecretMaxLength);

            // Get the 'hub.challenge' parameter and echo it back to caller
            NameValueCollection queryParameters = request.RequestUri.ParseQueryString();
            string challenge = queryParameters[ChallengeParameter];
            if (string.IsNullOrEmpty(challenge))
            {
                string msg = string.Format(CultureInfo.CurrentCulture, InstagramReceiverResources.Receiver_NoChallenge, ChallengeParameter);
                request.GetConfiguration().DependencyResolver.GetLogger().Error(msg);
                HttpResponseMessage noEcho = request.CreateErrorResponse(HttpStatusCode.BadRequest, msg);
                return noEcho;
            }

            // Return the echo response
            HttpResponseMessage challengeResponse = request.CreateResponse();
            challengeResponse.Content = new StringContent(challenge);
            return challengeResponse;
        }

        /// <summary>
        /// Gets the notification actions form the given <paramref name="data"/>.
        /// </summary>
        /// <param name="data">The request body.</param>
        /// <param name="request">The current <see cref="HttpRequestMessage"/>.</param>
        /// <returns>A collection of actions.</returns>
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Response is disposed by infrastructure.")]
        protected virtual IEnumerable<string> GetActions(JArray data, HttpRequestMessage request)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            try
            {
                List<string> actions = new List<string>();
                foreach (JObject e in data)
                {
                    string action = e.Value<string>(ActionKey);
                    if (action != null)
                    {
                        actions.Add(action);
                    }
                }
                return actions;
            }
            catch (Exception ex)
            {
                string msg = string.Format(CultureInfo.CurrentCulture, InstagramReceiverResources.Receiver_BadEvent, ex.Message);
                request.GetConfiguration().DependencyResolver.GetLogger().Error(msg, ex);
                HttpResponseMessage invalidData = request.CreateErrorResponse(HttpStatusCode.BadRequest, msg);
                throw new HttpResponseException(invalidData);
            }
        }
    }
}
