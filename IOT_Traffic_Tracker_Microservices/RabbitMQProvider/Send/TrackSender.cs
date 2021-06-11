using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQProvider.Config;

namespace RabbitMQProvider.Send
{
    public class TrackSender : Sender, ITrackSender
    {
        public TrackSender(IRabbitMQConfiguration rabbitMqOptions)
               :base(rabbitMqOptions, rabbitMqOptions.TracksQueueName)
        {
        }
    }
}
