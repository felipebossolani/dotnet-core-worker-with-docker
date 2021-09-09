using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace dotnet_core_worker_with_docker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IHostApplicationLifetime _hostApplicationLifetime;
        private readonly WorkerOptions _workerOptions;

        public Worker(ILogger<Worker> logger, IHostApplicationLifetime hostApplicationLifetime, WorkerOptions workerOptions)
        {
            _logger = logger;
            _hostApplicationLifetime = hostApplicationLifetime;
            _workerOptions = workerOptions;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var delayInMilleseconds = _workerOptions.DelayInMilliseconds;
            _logger.LogInformation($"Starting an emulated worker. ETA: {delayInMilleseconds}. Started running at: {DateTimeOffset.Now}");
            await Task.Delay(delayInMilleseconds, stoppingToken);
            _logger.LogInformation($"Finishing worker. Finished at: {DateTimeOffset.Now}");

            _hostApplicationLifetime.StopApplication();
        }
    }
}
