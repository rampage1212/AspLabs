﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http.Controllers;

namespace Microsoft.AspNet.WebHooks
{
    /// <summary>
    /// Provides context for an incoming WebHook request. The context is passed to registered <see cref="IWebHookHandler"/> implementations 
    /// which can process the incoming request accordingly.
    /// </summary>
    public class WebHookHandlerContext
    {
        private List<string> _actions = new List<string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="WebHookHandlerContext"/> with the given set of <paramref name="actions"/>.
        /// </summary>
        public WebHookHandlerContext(IEnumerable<string> actions)
        {
            if (actions == null)
            {
                throw new ArgumentNullException("actions");
            }
            _actions.AddRange(actions);
        }

        /// <summary>
        /// Provides the set of actions that caused the WebHook to be fired.
        /// </summary>
        public IEnumerable<string> Actions
        {
            get
            {
                return _actions;
            }
        }

        /// <summary>
        /// Gets or sets the optional data associated with this WebHook. The data typically represents the
        /// HTTP request entity body of the incoming WebHook but can have been processed in various ways
        /// by the corresponding <see cref="IWebHookReceiver"/>.
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="HttpRequestMessage"/> containing the WebHook.
        /// </summary>
        public HttpRequestMessage Request { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="HttpRequestContext"/> for the incoming 
        /// </summary>
        public HttpRequestContext RequestContext { get; set; }

        /// <summary>
        /// Gets or sets an optional <see cref="HttpResponseMessage"/> for the WebHook. If set by an <see cref="IWebHookHandler"/> 
        /// then the execution of handlers will stop and that response will be used in response to the WebHook request.
        /// If a response is not set then a default HTTP response will be sent. 
        /// </summary>
        public HttpResponseMessage Response { get; set; }
    }
}