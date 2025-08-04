using LinkService;

namespace TGrpcService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            LinkFunc.LinkServerStart("127.0.0.1", 9008);
            Thread.Sleep(500);
            LinkFunc.ReplyMes = ReplyMes;
            LinkFunc.ReplyMesList = ReplyList;
            Console.ReadKey();
        }

        private static IEnumerable<Mes> ReplyList(string strRequest)
        {
            Console.WriteLine("接收到:" + strRequest);
            switch (strRequest)
            {
                case "3":
                    return new List<Mes> { new Mes { StrReply = "Server识别到1" }, new Mes { StrReply = "Server识别到11" }, new Mes { StrReply = "Server识别到111" } };
                case "4":
                    return new List<Mes> { new Mes { StrReply = "Server识别到2" }, new Mes { StrReply = "Server识别到22" }, new Mes { StrReply = "Server识别到222" } };
                case "5":
                    return new List<Mes> { new Mes { StrReply = "开始测试5" }, new Mes { StrReply = "开始测试6" } };
                case "6":
                    return new List<Mes> { new Mes { StrReply = "true7" } , new Mes { StrReply = "true8" } };
            }
            return new List<Mes> { new Mes { StrReply = "Server未识别到指定参数" } };
        }

        /// <summary>
        /// 接收到客户端信息后回复
        /// </summary>
        /// <param name="strRequest">客户端发送过来的内容</param>
        /// <returns></returns>
        public static string ReplyMes(string strRequest)
        {
            Console.WriteLine("接收到:" + strRequest);
            switch (strRequest)
            {
                case "1":
                    return "Server识别到1";
                case "2":
                    return "Server识别到2";
                case "测试":
                    return "开始测试";
                case "连接服务端":
                    return "true";
            }
            return "Server未识别到指定参数";
        }
    }
}
