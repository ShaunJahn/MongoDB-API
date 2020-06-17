using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Portal.Controller;
using Portal.Shared;

namespace Portal.Hubs
{
    class UserInfo
    {

        public static HashSet<string> ConnectedIds = new HashSet<string>();
        public static HashSet<string> ConntionLogs = new HashSet<string>();
        private static readonly Dictionary<string, string> userLookup = new Dictionary<string, string>();
    }
    public class ChatHub : Hub
    {
        private static readonly Dictionary<string, string> userLookup = new Dictionary<string, string>();
        public async Task SendMessage(string username, string message)
        {
            await Clients.All.SendAsync("RECEIVE", username, message);
        }

        //Register is the method nae use SendAsync(name) to call it!
        public async Task Register(string username)
        {
            var currentId = Context.ConnectionId;
            if (!userLookup.ContainsKey(currentId))
            {
                userLookup.Add(currentId, username);
                await Clients.All.SendAsync(
                    "REGISTERED",
                    username, "joined the chat", userLookup.Count, userLookup);
            }
        }

        public override async Task OnConnectedAsync()
        {
                        //UserInfo.ConnectedIds.Remove(Context.ConnectionId);
            //await Clients.All.SendAsync("OnlineUsers", UserInfo.numUsers, UserInfo.ConnectedIds, UserInfo.ConntionLogs);
        }



        public override async Task OnDisconnectedAsync(Exception exception)
        {
            //UserInfo.ConnectedIds.Remove(Context.ConnectionId);
            var userName = userLookup[Context.ConnectionId];
            userLookup.Remove(Context.ConnectionId);
            await Clients.All.SendAsync(
                    "REGISTERED",
                    userName, "left the chat", userLookup.Count, userLookup);
        }
    }
}
