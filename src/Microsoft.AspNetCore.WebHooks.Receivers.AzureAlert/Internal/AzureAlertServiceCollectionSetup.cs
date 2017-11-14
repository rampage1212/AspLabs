﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNetCore.WebHooks.Metadata;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.AspNetCore.WebHooks.Internal
{
    /// <summary>
    /// Methods to add services for the Azure Alert receiver.
    /// </summary>
    public static class AzureAlertServiceCollectionSetup
    {
        /// <summary>
        /// Add services for the Azure Alert receiver.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to update.</param>
        public static void AddAzureAlertServices(IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.TryAddEnumerable(ServiceDescriptor.Singleton<IWebHookMetadata, AzureAlertMetadata>());
        }
    }
}
