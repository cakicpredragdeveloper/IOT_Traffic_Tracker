using CommandProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRProvider.HubConfig
{
    public interface ICommandHub
    {
        Task DisplayMessage(string message);

        Task Commands(Command command);
    }
}
