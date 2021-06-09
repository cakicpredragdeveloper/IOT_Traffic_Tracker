using System;
using System.Collections.Generic;
using System.Text;
using DataProvider.Repositories;
using DataProvider.Entities;
using Newtonsoft.Json;

namespace RabbitMQProvider.Receive
{
    public class TrackReceiver : IOnMessageReceivedService
    {
        private readonly ITrackRepository _trackRepository;

        public TrackReceiver(ITrackRepository trackRepository)
        {
            _trackRepository = trackRepository;
        }

        public void Do(string content)
        {
            var track = JsonConvert.DeserializeObject<Track>(content);

            Console.WriteLine(track);

        }
    }
}
