using Grpc.Core;
using Grpc.Core.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGrpcService
{
    public class ServiceInterceptor : Interceptor
    {
        private readonly string _serviceName;
        public ServiceInterceptor(string serviceName)
        {
            _serviceName = serviceName;
        }
        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(TRequest request, ServerCallContext context, UnaryServerMethod<TRequest, TResponse> continuation)
        {
            // 在这里可以添加日志、验证等逻辑
            Metadata requestHeader;
            if (context.RequestHeaders == null)
            {
                requestHeader = new Metadata();
            }
            else
            {
                requestHeader = context.RequestHeaders;
            }
            Console.WriteLine($"***Service: {_serviceName}, Begin, Method: {context.Method}, Request: {request}");
            var response = await base.UnaryServerHandler(request, context, continuation);
            Console.WriteLine($"***Service: {_serviceName}, End, Method: {context.Method}, response: {response}");
            return response;
        }
    }
}
