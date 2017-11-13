﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Microsoft.AspNetCore.WebHooks.Metadata
{
    /// <summary>
    /// An <see cref="IWebHookMetadata"/> service containing metadata about the Dynamics CRM receiver.
    /// </summary>
    public class DynamicsCRMMetadata : WebHookMetadata, IWebHookRequestMetadataService, IWebHookSecurityMetadata
    {
        /// <summary>
        /// Instantiates a new <see cref="DynamicsCRMMetadata"/> instance.
        /// </summary>
        public DynamicsCRMMetadata()
            : base(DynamicsCRMConstants.ReceiverName)
        {
        }

        // IWebHookRequestMetadataService...

        /// <inheritdoc />
        public WebHookBodyType BodyType => WebHookBodyType.Json;

        // IWebHookSecurityMetadata...

        /// <inheritdoc />
        public bool VerifyCodeParameter => true;

        /// <inheritdoc />
        public bool ShortCircuitGetRequests => false;

        /// <inheritdoc />
        public WebHookGetRequest WebHookGetRequest => null;
    }
}
