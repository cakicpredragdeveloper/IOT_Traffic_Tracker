using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AnalyticsService.Services;
using Microsoft.Extensions.Logging;
using RabbitMQProvider.Receive;
using DataProvider.Repositories;
using RabbitMQProvider.Config;

namespace AnalyticsService.Services
{
    public class BackgroundReceiver : IHostedService
    {
        private readonly ILogger<BackgroundReceiver> _logger;
        private readonly IRabbitMQConfiguration _rabbitMQConfiguration;
        private readonly ITrackRepository _trackRepository;

        public BackgroundReceiver(ILogger<BackgroundReceiver> logger, IRabbitMQConfiguration rabbitConf, ITrackRepository trackRepository)
        {
            _logger = logger;
            _rabbitMQConfiguration = rabbitConf;
            _trackRepository = trackRepository;
        }


        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("*************************************");

            new Receiver(_rabbitMQConfiguration, new TrackReceiver(_trackRepository));
            
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("*************************************");
            return Task.CompletedTask;
        }
    }
}
