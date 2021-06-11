using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQProvider.Config
{
    public interface IRabbitMQConfiguration
    {
        string Hostname { get; set; }

        string UserName { get; set; }

        string Password { get; set; }

        string TracksQueueName { get; set; }
        
        string AnalyticCommandQueueName { get; set; }
    }
}
