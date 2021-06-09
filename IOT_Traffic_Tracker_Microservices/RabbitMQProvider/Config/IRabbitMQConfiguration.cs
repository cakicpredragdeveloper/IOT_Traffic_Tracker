using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQProvider.Config
{
    public interface IRabbitMQConfiguration
    {
        string Hostname { get; set; }

        string QueueName { get; set; }

        string UserName { get; set; }

        string Password { get; set; }
    }
}
