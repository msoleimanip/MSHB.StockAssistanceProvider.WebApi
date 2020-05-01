using Microsoft.Extensions.Logging;
using MSHB.StockAssistanceProvider.Layers.L03_Services.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using tsetmcWebService;

namespace MSHB.StockAssistanceProvider.Layers.L03_Services.Impls
{
    public class ScopedProcessingService : IScopedProcessingService
    {
        private int executionCount = 0;
        private readonly ILogger _logger;

        public ScopedProcessingService(ILogger<ScopedProcessingService> logger)
        {
            _logger = logger;
        }
        public async  Task DoWork(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                executionCount++;
                var client = new TsePublicV2SoapClient(TsePublicV2SoapClient.EndpointConfiguration.TsePublicV2Soap);
               DataTable table = null;
                var optionResponse = client.Option(new OptionRequest(".com", ""));
            






                _logger.LogInformation(
                    "Scoped Processing Service is working. Count: {Count}", executionCount);

                await Task.Delay(100000, stoppingToken);
            }
        }
    }
}
