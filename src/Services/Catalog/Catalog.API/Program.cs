using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Catalog.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config)=>
                    {
                        config.Sources.Clear();
                        var env = hostingContext.HostingEnvironment;
                        config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", 
                                            optional: true, reloadOnChange: true);
                        /*
                        config.AddJsonFile("MyConfig.json", optional: true, reloadOnChange: true)
                            .AddJsonFile($"MyConfig.{env.EnvironmentName}.json",
                                            optional: true, reloadOnChange: true);
                        */
                        config.AddEnvironmentVariables();
                        if (args != null)
                        {
                            config.AddCommandLine(args);
                        }
                    }
                )
                .ConfigureWebHostDefaults((webBuilder) =>
                {

                    webBuilder.UseStartup<Startup>();
                });
    }
}
