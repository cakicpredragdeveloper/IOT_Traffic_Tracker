using System;
using System.Collections.Generic;
using System.Text;
using DataProvider.Entities;

namespace RabbitMQProvider.Send
{
    public interface ISender
    {

        void Send(object obj);
    }
}
