using ChattrApi.Models;
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

            await Clients.OthersInGroup(groupName).SendAsync("downloadMessage", $"{user} has joined {groupName}.");
        }

        //send message to chat room
        public async Task NewMessage(AvatarMessageModel message, string groupName)
        {
            await Clients.Group(groupName).SendAsync("downloadMessage", message, groupName);
        }

        public async Task RemoveFromChat(string groupName, string user)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
            await Clients.OthersInGroup(groupName).SendAsync("downloadMessage", $"{user} has left {groupName}.");

        }
    }
}
