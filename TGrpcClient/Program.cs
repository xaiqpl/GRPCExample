namespace TGrpcClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(4000);
            Console.WriteLine("Hello, World!");
            LinkFunc.LinkClientStart("127.0.0.1:9008");
            Console.WriteLine("连接服务端中");
            string conn = LinkFunc.SendMesAsync("连接服务端").Result;

            if (conn.Equals("true"))
            {
                Console.WriteLine("连接服务端成功!");

                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("输入测试内容..");
                    var line = Console.ReadLine();
                    var ret = LinkFunc.SendMes(line);
                    //获取到服务端返回的值
                    Console.WriteLine("link say:" + ret);
               
                    var ret1 = LinkFunc.SendGreeter(line);
                    Console.WriteLine("greeate say:" + ret1);

                    var ret2 = LinkFunc.SendMesList(line);
                    int count = 1;
                    foreach (var mes in ret2)
                    {
                        Console.WriteLine("link say:" + count++ +", "+ mes.StrReply);                       
                    }
                }
            }

            Console.WriteLine("连接失败 , 即将退出");
            Console.ReadKey();
            Thread.Sleep(2000);
        }
    }
}
