using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQProvider.Config
{
    public class RabbitMQConfiguration: IRabbitMQConfiguration
    {
        public string Hostname { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
        
        public string TracksQueueName { get; set; }
        
        public string AnalyticCommandQueueName { get; set; }
    }
}
