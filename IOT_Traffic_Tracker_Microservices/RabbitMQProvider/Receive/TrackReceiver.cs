using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQProvider.Config;
using RabbitMQProvider.Send;
using DataProvider.Repositories;
using Newtonsoft.Json;
using DataProvider.Entities;

namespace RabbitMQProvider.Receive
{
    public class TrackReceiver : Receiver
    {
        private readonly IRabbitMQConfiguration _rabbitMQConfiguration;
        private readonly ITrackRepository _trackRepository;
        private readonly IAnalyticCommandSender _analyticCommandSender;

        public TrackReceiver(IRabbitMQConfiguration rabbitConf, ITrackRepository trackRepository, IAnalyticCommandSender analyticCommandSender)
                : base(rabbitConf, rabbitConf.TracksQueueName)
        {
            _rabbitMQConfiguration = rabbitConf;
            _trackRepository = trackRepository;
            _analyticCommandSender = analyticCommandSender;
        }

        protected override void HandleMessage(string content)
        {
            throw new NotImplementedException();

            // TODO: Ovde dobijes jedan po jedan track
            var track = JsonConvert.DeserializeObject<Track>(content);
            Console.WriteLine(track);


            // TODO: Ovde saljes komande Command Servisu :)
            _analyticCommandSender.Send(null);
        }
    }
}
