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

        protected override async void HandleMessage(string content)
        {
            throw new NotImplementedException();

            // TODO: Ovde dobijes jedan po jedan track
           var tracks = JsonConvert.DeserializeObject<List<Track>>(content);

            foreach(var track in tracks)
            {
                AnaliticsResult analiticsResult = new AnaliticsResult()
                {
                    Id = await _trackRepository.GetNextAnaliticsResultId(),
                    RecordId = track.RecordId
                };

                if (track.Speed > 20)
                {
                    if (track.BusCount > 2)
                    {
                        analiticsResult.Status = "dangeorous";
                    }
                    else analiticsResult.Status = "medium securely";
                }
                else analiticsResult.Status = "securely";

                await _trackRepository.Create(analiticsResult);
            }

            // TODO: Ovde saljes komande Command Servisu :)
            //_analyticCommandSender.Send(null);
        }
    }
}
