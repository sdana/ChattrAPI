using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChattrApi.Hubs
{
    [EnableCors("CorsPolicy")]
    public class ChatHub : Hub
    {
        //Add user to chat room
        public async Task AddToGroup(string groupName, string user)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

            await Clients.Caller.SendAsync("downloadPreviousMessages", groupName);

            await Clients.OthersInGroup(groupName).SendAsync("downloadMessage", $"{user} has joined the group {groupName}.");
        }

        //send message to chat room
        public async Task NewMessage(string message, string groupName, string user)
        {
            await Clients.Group(groupName).SendAsync("downloadMessage", $"{user}: {message}", groupName);
        }

        public async Task RemoveFromChat(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }
    }
}
