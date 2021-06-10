using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQProvider.Config;
using RabbitMQProvider.Send;
using DataProvider.Repositories;

namespace RabbitMQProvider.Receive
{
    public class TrackReceiver : Receiver
    {
        private readonly IRabbitMQConfiguration _rabbitMQConfiguration;
        private readonly ITrackRepository _trackRepository;
        private readonly IAnalyticCommandSender _analyticCommandSender;

        public TrackReceiver(IRabbitMQConfiguration rabbitConf, ITrackRepository trackRepository, IAnalyticCommandSender analyticCommandSender)
                : base(rabbitConf, rabbitConf.TracksQueueName, new OnTrackReceived(trackRepository, analyticCommandSender))
        {
            _rabbitMQConfiguration = rabbitConf;
            _trackRepository = trackRepository;
            _analyticCommandSender = analyticCommandSender;
        }
    }
}
