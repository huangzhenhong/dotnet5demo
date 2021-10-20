using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet5.WebApi.SignalrDemo.Hubs
{
    public class ChatHub: Hub
    {
        public Task SendMessage(string user, string message)
        {
            // Calls a method on the client that invoked the hub method
            Clients.Caller.SendAsync("ReceiveMessage", user, message);

            //Calls a method on all connected clients except the client that invoked the method
            Clients.Caller.SendAsync("ReceiveMessage", user, message);
            
            // Calls a method on all connected clients
            return Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
