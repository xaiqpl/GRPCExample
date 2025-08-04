using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkService;
using GrpcDemo;
using Grpc.Core.Interceptors;

namespace TGrpcService
{
    public class LinkFunc
    {
        public static Func<string, string> ReplyMes;
        public static Func<string,IEnumerable<Mes>> ReplyMesList;
        public static Server LinkServer;
        public  static void LinkServerStart(string host, int port)
        {
            LinkServer = new Server
            {
                Services =
                    {
                      Link.BindService(new LinkServerFunc()).Intercept(new ServiceInterceptor("LinK:")),
                      GrpcDemo.Greeter.BindService(new GreeterService()).Intercept(new ServiceInterceptor("Greeter:"))

                    },
                Ports = { new ServerPort(host, port, ServerCredentials.Insecure) }
            };                
            LinkServer.Start();
        }
        /// <summary>
        ///  服务端关闭
        /// </summary>
        public static void LinkServerClose()
        {
            LinkServer?.ShutdownAsync().Wait();
        }
    }
}
