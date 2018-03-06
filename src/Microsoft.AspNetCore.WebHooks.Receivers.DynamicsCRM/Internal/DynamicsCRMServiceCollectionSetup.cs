// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNetCore.WebHooks.Metadata;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.AspNetCore.WebHooks.Internal
{
    /// <summary>
    /// Methods to add services for the Dynamics CRM receiver.
    /// </summary>
    public static class DynamicsCRMServiceCollectionSetup
    {
        /// <summary>
        /// Add services for the Dynamics CRM receiver.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to update.</param>
        public static void AddDynamicsCRMServices(IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            WebHookMetadata.Register<DynamicsCRMMetadata>(services);
        }
    }
}
