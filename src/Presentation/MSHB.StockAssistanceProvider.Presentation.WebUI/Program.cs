﻿using System;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MSHB.StockAssistanceProvider.Layers.L03_Services.Contracts;
using MSHB.StockAssistanceProvider.Layers.L03_Services.Impls;
using MSHB.StockAssistanceProvider.Layers.L03_Services.Initialization;

namespace MSHB.StockAssistanceProvider.Presentation.WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
  

            
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializerService>();
                    dbInitializer.Initialize();
                    dbInitializer.SeedData();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            host.Run();

        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureServices(services =>
                {
                    services.AddHostedService<ConsumeScopedServiceHostedService>();
                    services.AddScoped<IScopedProcessingService, ScopedProcessingService>();

                })
                .UseKestrel(option =>
                {
                    option.Limits.MaxRequestBodySize = null;

                })
             .ConfigureLogging((hostingContext, logging) =>
             {
                 logging.AddDebug();
                 logging.AddConsole();
                 logging.AddLog4Net();
                 logging.SetMinimumLevel(LogLevel.Debug);
             })
                .UseIISIntegration() 
                .UseUrls("http://0.0.0.0:6000")
                .Build();
    }
}
