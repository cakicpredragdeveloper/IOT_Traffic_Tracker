using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using CommandProvider.Models;
using Microsoft.AspNetCore.SignalR;


namespace SignalRProvider.HubConfig
{
    public class CommandHub: Hub<ICommandHub>
    {
        public void Hello()
        {
            Clients.Caller.DisplayMessage("Hello from the SignalrDemoHub!");
        }
        /*
        public void sendToAll(Command command)
        {
            Clients.All.SendAsync("commands", command);
        }

        public async Task JoinRoom(string roomName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
        }
        public async Task LeaveRoom(string roomName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
        }

        public async Task SendMessage(string notification, string groupName)
        {
            await Clients.Group(groupName).SendAsync("commands", notification);
        }
        */
    }
}
