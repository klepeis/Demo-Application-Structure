using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Product.API.BackgroundTasks.Options;

namespace Product.API.BackgroundTasks.Tasks
{
    public class PollingTask : BackgroundService
    {
        private readonly ILogger<PollingTask> _logger;
        private readonly PollingTaskOptions _pollingTaskOptions;

        public PollingTask(ILogger<PollingTask> logger, IOptions<PollingTaskOptions> pollingTaskOptions)
        {
            _logger = logger;
            _pollingTaskOptions = pollingTaskOptions.Value;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogDebug("PollingTask is starting");

            stoppingToken.Register(() =>
                _logger.LogDebug("PollingTask is stopping")
            );

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogDebug("PollingTask doing background work.");

                //Do Something

                await Task.Delay(TimeSpan.FromSeconds(_pollingTaskOptions.PollingIntervalSeconds), stoppingToken);
            }

            _logger.LogDebug("PollingTask is stopping.");
        }
    }
}
