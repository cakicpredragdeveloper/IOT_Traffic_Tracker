using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RabbitMQProvider.Config;
using CommandProvider.Models;


namespace RabbitMQProvider.Receive
{
    public class AnalyticCommandReceiver : Receiver
    {
        private readonly IRabbitMQConfiguration _rabbitMQConfiguration;

        public AnalyticCommandReceiver(IRabbitMQConfiguration rabbitConf)
                : base(rabbitConf, rabbitConf.AnalyticCommandQueueName)
        {
            _rabbitMQConfiguration = rabbitConf;
        }

        protected override async void HandleMessage(string content)
        {
           var command =  JsonConvert.DeserializeObject<Command>(content);
           await  command.Execute();

            //TODO: SignalR obrada...
        }
    }
}
