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
                : base(rabbitConf, rabbitConf.AnalyticCommandQueueName, new OnAnalyticCommandMessasgeReceived())
        {
            _rabbitMQConfiguration = rabbitConf;
        }
    }
}
