using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQProvider.Config;

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

        protected override void HandleMessage(string content)
        {
            throw new NotImplementedException();

            // TODO ovde na osnovu komande saljes REST PUT / POST zahtev sa „komandom“ Device Microservisu
        }
    }
}
