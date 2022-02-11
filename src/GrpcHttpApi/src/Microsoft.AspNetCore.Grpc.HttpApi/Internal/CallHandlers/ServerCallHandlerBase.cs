// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Grpc.AspNetCore.Server;
using Grpc.Core;
using Grpc.Shared.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Microsoft.AspNetCore.Grpc.HttpApi.Internal.CallHandlers
{
    internal abstract class ServerCallHandlerBase<TService, TRequest, TResponse>
        where TService : class
        where TRequest : class
        where TResponse : class
    {
        private const string LoggerName = "Grpc.AspNetCore.Grpc.HttpApi.ServerCallHandler";

        protected ServerMethodInvokerBase<TService, TRequest, TResponse> MethodInvoker { get; }
        public JsonSerializerOptions SerializerOptions { get; }
        protected ILogger Logger { get; }

        protected ServerCallHandlerBase(
            ServerMethodInvokerBase<TService, TRequest, TResponse> methodInvoker,
            ILoggerFactory loggerFactory,
            JsonSerializerOptions serializerOptions)
        {
            MethodInvoker = methodInvoker;
            SerializerOptions = serializerOptions;
            Logger = loggerFactory.CreateLogger(LoggerName);
        }

        public Task HandleCallAsync(HttpContext httpContext)
        {
            var serverCallContext = new HttpApiServerCallContext(httpContext, MethodInvoker.Options, MethodInvoker.Method.FullName, Logger);
            httpContext.Features.Set<IServerCallContextFeature>(serverCallContext);

            try
            {
                var handleCallTask = HandleCallAsyncCore(httpContext, serverCallContext);

                if (handleCallTask.IsCompletedSuccessfully)
                {
                    return serverCallContext.EndCallAsync();
                }
                else
                {
                    return AwaitHandleCall(serverCallContext, MethodInvoker.Method, SerializerOptions, handleCallTask);
                }
            }
            catch (Exception ex)
            {
                return serverCallContext.ProcessHandlerErrorAsync(ex, MethodInvoker.Method.Name, SerializerOptions);
            }

            static async Task AwaitHandleCall(HttpApiServerCallContext serverCallContext, Method<TRequest, TResponse> method, JsonSerializerOptions serializerOptions, Task handleCall)
            {
                try
                {
                    await handleCall;
                    await serverCallContext.EndCallAsync();
                }
                catch (Exception ex)
                {
                    await serverCallContext.ProcessHandlerErrorAsync(ex, method.Name, serializerOptions);
                }
            }
        }

        protected abstract Task HandleCallAsyncCore(HttpContext httpContext, HttpApiServerCallContext serverCallContext);
    }
}
