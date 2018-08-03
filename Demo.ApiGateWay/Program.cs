using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Demo.ApiGateWay
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("http://*:5000")
                .ConfigureAppConfiguration((hostingContext, builder) =>
                {
                    // 静态配置
                    //builder.AddJsonFile("ocelot.json", false, true);

                    // consul服务发现
                    //builder.AddJsonFile("ocelot-consul.json", false, true);

                    // 动态路由
                    builder.AddJsonFile("Ocelot-DynamicRouting.json", false, true);
                });
    }
}
