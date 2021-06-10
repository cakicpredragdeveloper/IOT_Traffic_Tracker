using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQProvider.Receive
{
    public interface IOnMessageReceived
    {
        void Do(string obj);
    }
}
