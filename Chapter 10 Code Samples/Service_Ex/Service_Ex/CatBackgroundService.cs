using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Service_Ex
{
    public sealed class CatBackgroundService : BackgroundService
    {
        private readonly CatService _catService;
        private readonly ILogger<CatBackgroundService> _logger;

        public CatBackgroundService(
            CatService catService,
            ILogger<CatBackgroundService> logger) =>
            (_catService, _logger) = (catService, logger);

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    string catFact = await _catService.GetCatFactAsync();
                    _logger.LogWarning(catFact);

                    await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
                }
                catch (OperationCanceledException)
                {
                    break;
                }
            }
        }
    }
}