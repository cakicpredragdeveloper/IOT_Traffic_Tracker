using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RabbitMQProvider.Config;
using CommandProvider.Models;
using DataProvider.Repositories;
using SignalRProvider.HubConfig;
using Microsoft.AspNetCore.SignalR;

namespace RabbitMQProvider.Receive
{
    public class AnalyticCommandReceiver : Receiver
    {
        private readonly IRabbitMQConfiguration _rabbitMQConfiguration;
        private readonly ICommandRepository _commandRepository;
        private readonly IHubContext<CommandHub> _hub;


        public AnalyticCommandReceiver(IRabbitMQConfiguration rabbitConf, ICommandRepository commandRepository, IHubContext<CommandHub> hub)
                : base(rabbitConf, rabbitConf.AnalyticCommandQueueName)
        {
            _rabbitMQConfiguration = rabbitConf;
            _commandRepository = commandRepository;
            _hub = hub;
        }

        protected override async void HandleMessage(string content)
        {
            var command =  JsonConvert.DeserializeObject<Command>(content);

            command.Id = await _commandRepository.GetNextId();
            await _commandRepository.Create(command);

            Console.WriteLine("new command: " + command.Id + " " + command.Code + " " + command.DateTime.ToString() + " " + command.RecordId + " " + command.Status);

            await  command.Execute();



            // SignalR obrada...
            _ = _hub.Clients.All.SendAsync("commands", command);
        }
    }
}
