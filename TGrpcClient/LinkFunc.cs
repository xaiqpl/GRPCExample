using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkService;
using System;
using static LinkService.Link;
using GrpcDemo;
namespace TGrpcClient
{
    public class LinkFunc
    {        
       
        public static LinkClient LinkClient;
        public static Greeter.GreeterClient greeterClient;

        /// <summary>
        /// 客户端启动
        /// </summary>
        /// <param name="strIp"></param>
        public static void LinkClientStart(string strIp)
        {
            Channel prechannel = new Channel(strIp, ChannelCredentials.Insecure);
            LinkClient = new LinkClient(new ClientLoggingInvoker(prechannel, "link.log"));
            greeterClient=new Greeter.GreeterClient(new ClientLoggingInvoker(prechannel, "greeter.log"));
        }

        /// <summary>
        /// 客户端发送消息函数
        /// </summary>
        /// <param name="strRequest"></param>
        /// <returns></returns>
        public static string SendMes(string strRequest)
        {
            Mes mes = new Mes();
            mes.StrRequest = strRequest;
            var res = LinkClient.GetMessage(mes);
            return res.StrReply;
        }
        public static Task<string> SendMesAsync(string strRequest)
        {
            Mes mes = new Mes();
            mes.StrRequest = strRequest;
            return LinkClient.GetMessageAsync(mes).ResponseAsync.ContinueWith(t => t.Result.StrReply);
        }

        public static IEnumerable<Mes> SendMesList(string strRequest)
        {
            Mes mes = new Mes();
            mes.StrRequest = strRequest;
            var res = LinkClient.GetMessageList(mes);
            return res.MesList_;
        }

        public static string SendGreeter(string strRequest)
        {           
            HelloRequest helloRequest = new HelloRequest { Name = strRequest };
            var res = greeterClient.SayHello(helloRequest);
            return res.Message;
        }
    }
}
