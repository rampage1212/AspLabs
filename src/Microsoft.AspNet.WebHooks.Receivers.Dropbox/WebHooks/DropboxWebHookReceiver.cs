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
    /// Provides an <see cref="IWebHookReceiver"/> implementation which support WebHooks generated by Dropbox. 
    /// Set the '<c>MS_WebHookReceiverSecret_Dropbox</c>' application setting to the secret defined in Dropbox.
    /// The corresponding WebHook URI is of the form '<c>https://&lt;host&gt;/api/webhooks/incoming/dropbox</c>'.
    /// For details about Dropbox WebHooks, see <c>https://www.dropbox.com/developers/webhooks/docs</c>.
    /// </summary>
    public class DropboxWebHookReceiver : WebHookReceiver
    {
        internal const string SecretKey = "MS_WebHookReceiverSecret_Dropbox";

        internal const string SignatureHeaderName = "X-Dropbox-Signature";
        internal const string ChallengeParameter = "challenge";
        internal const string DefaultAction = "change";

        private static readonly string[] ReceiverNames = new string[] { "dropbox" };

        /// <inheritdoc />
        public override IEnumerable<string> Names
        {
            get { return ReceiverNames; }
        }

        /// <inheritdoc />
        public override async Task<HttpResponseMessage> ReceiveAsync(string receiver, HttpRequestContext context, HttpRequestMessage request)
        {
            if (receiver == null)
            {
                throw new ArgumentNullException("receiver");
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
                bool valid = await VerifySignature(request);
                if (!valid)
                {
                    return CreateBadSignatureResponse(request, SignatureHeaderName);
                }

                // Read the request entity body
                JObject data = await ReadAsJsonAsync(request);

                // Call registered handlers
                return await ExecuteWebHookAsync(receiver, context, request, new string[] { DefaultAction }, data);
            }
            else if (request.Method == HttpMethod.Get)
            {
                return WebHookVerification(request);
            }
            else
            {
                return CreateBadMethodResponse(request);
            }
        }

        /// <summary>
        /// Verifies that the signature header matches that of the actual body.
        /// </summary>
        protected virtual async Task<bool> VerifySignature(HttpRequestMessage request)
        {
            string secretKey = GetWebHookSecret(request, SecretKey, 8, 64);

            // Get the expected hash from the signature header
            string signatureHeaderValue = GetRequestHeader(request, SignatureHeaderName);

            byte[] expectedHash;
            try
            {
                expectedHash = EncodingUtilities.FromHex(signatureHeaderValue);
            }
            catch (Exception ex)
            {
                string msg = string.Format(CultureInfo.CurrentCulture, DropboxReceiverResources.Receiver_BadHeaderEncoding, SignatureHeaderName);
                request.GetConfiguration().DependencyResolver.GetLogger().Error(msg, ex);
                HttpResponseMessage invalidEncoding = request.CreateErrorResponse(HttpStatusCode.BadRequest, msg);
                throw new HttpResponseException(invalidEncoding);
            }

            // Get the actual hash of the request body
            byte[] actualHash;
            byte[] secret = Encoding.UTF8.GetBytes(secretKey);
            using (var hasher = new HMACSHA256(secret))
            {
                byte[] data = await request.Content.ReadAsByteArrayAsync();
                actualHash = hasher.ComputeHash(data);
            }

            // Now verify that the provided hash matches the expected hash.
            return WebHookReceiver.SignatureEqual(expectedHash, actualHash);
        }

        /// <summary>
        /// Creates a response to a WebHook verification GET request.
        /// </summary>
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Disposed by caller")]
        protected HttpResponseMessage WebHookVerification(HttpRequestMessage request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            // Verify that we have the secret as an app setting
            GetWebHookSecret(request, SecretKey, 8, 64);

            // Get the 'challenge' parameter from the request URI and echo it back to caller
            NameValueCollection queryParameters = request.RequestUri.ParseQueryString();
            string challenge = queryParameters[ChallengeParameter];
            if (string.IsNullOrEmpty(challenge))
            {
                string msg = string.Format(CultureInfo.CurrentCulture, DropboxReceiverResources.Receiver_NoChallenge, ChallengeParameter);
                request.GetConfiguration().DependencyResolver.GetLogger().Error(msg);
                HttpResponseMessage noEcho = request.CreateErrorResponse(HttpStatusCode.BadRequest, msg);
                return noEcho;
            }

            // Return the challenge response
            HttpResponseMessage challengeResponse = request.CreateResponse();
            challengeResponse.Content = new StringContent(challenge);
            return challengeResponse;
        }
    }
}
