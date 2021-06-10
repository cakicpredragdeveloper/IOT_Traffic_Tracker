using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQProvider.Receive
{
    public class OnAnalyticCommandMessasgeReceived : IOnMessageReceived
    {
        public void Do(string obj)
        {
            // TODO ovde na osnovu komande saljes REST PUT / POST zahtev sa „komandom“ Device Microservisu
        }
    }
}
