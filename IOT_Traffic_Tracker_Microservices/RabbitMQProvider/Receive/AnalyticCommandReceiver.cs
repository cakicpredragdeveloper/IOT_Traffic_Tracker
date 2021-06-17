using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RabbitMQProvider.Config;
using CommandProvider.Models;
using DataProvider.Repositories;

namespace RabbitMQProvider.Receive
{
    public class AnalyticCommandReceiver : Receiver
    {
        private readonly IRabbitMQConfiguration _rabbitMQConfiguration;
        private readonly ICommandRepository _commandRepository;

        public AnalyticCommandReceiver(IRabbitMQConfiguration rabbitConf, ICommandRepository commandRepository)
                : base(rabbitConf, rabbitConf.AnalyticCommandQueueName)
        {
            _rabbitMQConfiguration = rabbitConf;
            _commandRepository = commandRepository;
        }

        protected override async void HandleMessage(string content)
        {
            var command =  JsonConvert.DeserializeObject<Command>(content);

            command.Id = await _commandRepository.GetNextId();
            await _commandRepository.Create(command);

            Console.WriteLine("new command: " + command.Id + " " + command.Code + " " + command.DateTime.ToString() + " " + command.RecordId + " " + command.Status);

            await  command.Execute();


           

            //TODO: SignalR obrada...
        }
    }
}
