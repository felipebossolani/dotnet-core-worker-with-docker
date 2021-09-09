using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace dotnet_core_worker_with_docker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
             Host.CreateDefaultBuilder(args)
                 .ConfigureAppConfiguration((hostingContext, config) =>
                 {
                     config.AddJsonFile($"appsettings.json");
                     Console.WriteLine(Environment.GetEnvironmentVariable("DelayInMilliseconds"));
                 })
                .ConfigureServices((hostContext, services) =>
                {
                    var configuration = hostContext.Configuration;
                    var workerOptions = configuration.GetSection("WorkerOptions").Get<WorkerOptions>();

                    services.AddSingleton(workerOptions);
                    services.AddHostedService<Worker>(x =>
                        ActivatorUtilities.CreateInstance<Worker>(x, workerOptions)
                    );
                });
    }
}
