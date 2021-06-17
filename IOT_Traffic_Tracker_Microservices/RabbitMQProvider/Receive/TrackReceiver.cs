using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQProvider.Config;
using RabbitMQProvider.Send;
using DataProvider.Repositories;
using Newtonsoft.Json;
using DataProvider.Entities;
using SiddhiProvider.Services;

namespace RabbitMQProvider.Receive
{
    public class TrackReceiver : Receiver
    {
        private readonly IRabbitMQConfiguration _rabbitMQConfiguration;
        private readonly ISiddhiSender _siddhiSender;

        public TrackReceiver(IRabbitMQConfiguration rabbitConf, ISiddhiSender siddhiSender)
                : base(rabbitConf, rabbitConf.TracksQueueName)
        {
            _rabbitMQConfiguration = rabbitConf;
            _siddhiSender = siddhiSender;
        }

        protected override async void HandleMessage(string content)
        {
            var tracks = JsonConvert.DeserializeObject<List<Track>>(content);

            foreach(var track in tracks)
            {
                // TODO Uncomment me
                string result = await _siddhiSender.SendData(track);
            }
        }
    }
}
