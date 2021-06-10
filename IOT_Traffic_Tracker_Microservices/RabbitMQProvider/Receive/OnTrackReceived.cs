using System;
using System.Collections.Generic;
using System.Text;
using DataProvider.Repositories;
using DataProvider.Entities;
using Newtonsoft.Json;
using RabbitMQProvider.Send;

namespace RabbitMQProvider.Receive
{
    public class OnTrackReceived : IOnMessageReceived
    {
        private readonly ITrackRepository _trackRepository;
        private readonly IAnalyticCommandSender _analyticCommandSender;

        public OnTrackReceived(ITrackRepository trackRepository, IAnalyticCommandSender analyticCommandSender)
        {
            _trackRepository = trackRepository;
            _analyticCommandSender = analyticCommandSender;
        }

        public void Do(string content)
        {
            // TODO: Ovde dobijes jedan po jedan track
            var track = JsonConvert.DeserializeObject<Track>(content);
            Console.WriteLine(track);


            // TODO: Ovde saljes komande Command Servisu :)
            _analyticCommandSender.Send(null);

        }
    }
}
