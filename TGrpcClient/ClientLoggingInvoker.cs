using Grpc.Core;
using Grpc.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGrpcClient
{
    public class ClientLoggingInvoker : DefaultCallInvoker
    {
        private readonly string _logFile;
        public ClientLoggingInvoker(Channel channel, string logFile) : base(channel)
        {
            this._logFile = logFile;
        }
        /// <summary>
        /// 在客户端使用异步调用时记录日志
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="method"></param>
        /// <param name="host"></param>
        /// <param name="options"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public override AsyncUnaryCall<TResponse> AsyncUnaryCall<TRequest, TResponse>(Method<TRequest, TResponse> method, string host, CallOptions options, TRequest request)
        {           
            try
            {
                Console.WriteLine($"{_logFile} call AsyncUnaryCall: {method.Name},{request}");
                var response = base.AsyncUnaryCall(method, host, options, request);
                //异步方法不要取结果
                //异步方法不要取结果
                Console.WriteLine($"{_logFile} ,AsyncUnaryCall resp {method.Name},{{}}");
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine($"{_logFile} , resp {method.Name},{{}} ,{e.Message}");
                throw;
            }
        }
        /// <summary>
        /// 在客户端使用阻塞调用时记录日志
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="method"></param>
        /// <param name="host"></param>
        /// <param name="options"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public override TResponse BlockingUnaryCall<TRequest, TResponse>(Method<TRequest, TResponse> method, string host, CallOptions options, TRequest request)
        {
            try
            {
                Console.WriteLine($"{_logFile} call  BlockingUnaryCall: {method.Name},{request}");
                var response = base.BlockingUnaryCall(method, host, options, request);
                //异步方法不要取结果
                //异步方法不要取结果
                Console.WriteLine($"{_logFile}  BlockingUnaryCall, resp {method.Name},{response}");
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine($"{_logFile} , resp {method.Name},{{}} ,{e.Message}");
                throw;
            }
        }
    }
}
