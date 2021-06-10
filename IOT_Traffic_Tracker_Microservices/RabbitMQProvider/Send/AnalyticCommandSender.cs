using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQProvider.Config;

namespace RabbitMQProvider.Send
{
    public class AnalyticCommandSender : Sender, IAnalyticCommandSender
    {
        public AnalyticCommandSender(IRabbitMQConfiguration configuration)
                :base(configuration, configuration.AnalyticCommandQueueName)
        {
        }


    }
}
