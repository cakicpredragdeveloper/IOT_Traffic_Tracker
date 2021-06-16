using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;


namespace CommandService.HubConfig
{
    public class CommandHub: Hub
    {
        public void sendCommand()
        {
            Clients.All.SendAsync("commands", "C O M A N D");
        }
    }
}
