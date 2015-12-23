﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNet.Proxy;

namespace Microsoft.AspNet.Builder
{
    public static class ProxyExtension
    {
        /// <summary>
        /// Sends request to remote server as specified in options
        /// </summary>
        /// <param name="app"></param>
        /// <param name="configureOptions">Configure options for setting port, host, and scheme</param>
        /// <returns></returns>
        public static IApplicationBuilder RunProxy(this IApplicationBuilder app, Action<ProxyOptions> configureOptions)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }
            if (configureOptions == null)
            {
                throw new ArgumentNullException(nameof(configureOptions));
            }

            var options = new ProxyOptions();
            configureOptions(options);

            return app.UseMiddleware<ProxyMiddleware>(options);
        }
    }
}
