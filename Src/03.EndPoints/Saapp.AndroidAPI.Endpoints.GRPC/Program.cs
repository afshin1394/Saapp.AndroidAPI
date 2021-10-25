using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Saapp.AndroidAPI.Endpoints.GRPC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        // Additional configuration is required to successfully run gRPC on macOS.
        // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseKestrel(options =>
                    {
                        // set http2 protocol
                        options.ConfigureEndpointDefaults(endpoints => endpoints.Protocols = HttpProtocols.Http2);
                    });
                    webBuilder.ConfigureKestrel(options =>
                    {
                       
                        options.ListenAnyIP(5001, listenOptions =>
                        {
                            listenOptions.UseHttps("kestrel.pfx", "changeit");
                        });
                      
                        options.ListenAnyIP(5000);
                    });
                });
    }
}
