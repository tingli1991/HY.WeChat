using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Stack.WeChat.Log4Net;
using System.IO;
using Stack.WeChat.MP.Extensions;

namespace Stack.WeChat.WebAPI
{
    /// <summary>
    /// 程序主入口
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 程序主函数
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Run();
        }

        /// <summary>
        /// 创建web站点编译
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHost CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseKestrel()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseIISIntegration()
            .UseStartup<Startup>()
            .UseLog4net($"{Directory.GetCurrentDirectory()}\\Config\\log4net.config")
            .RegisterMessageHandler("Stack.WeChat.Service")
            .Build();
    }
}