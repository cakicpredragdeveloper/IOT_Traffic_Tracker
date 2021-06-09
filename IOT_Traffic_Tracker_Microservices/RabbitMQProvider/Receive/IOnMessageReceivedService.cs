using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQProvider.Receive
{
    public interface IOnMessageReceivedService
    {
        void Do(string obj);
    }
}
