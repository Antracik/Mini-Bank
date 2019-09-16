using Microsoft.AspNetCore.SignalR;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Bank.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IUserService _userService;
        private static LinkedList<string> usersList = null;

        public ChatHub(IUserService userService)
        {
            _userService = userService;
            if (usersList == null)
            {
                usersList = new LinkedList<string>();
            }
        }

        public override async Task OnConnectedAsync()
        {
            string user = Context.User.Identity.Name;

            if (!usersList.Contains(user))
            {
                usersList.AddLast(Context.User.Identity.Name);
                user = _userService.IsUserSignedInAsAdmin(Context.User) ? "Admin" : user;
                await Clients.Others.SendAsync("ReceiveMessage", "System", $" {user} has joined the chat, say hello!");
            }

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            usersList.Remove(Context.User.Identity.Name);
            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string message)
        {
            if (usersList.Contains(Context.User.Identity.Name))
            {
                if (!string.IsNullOrWhiteSpace(message))
                {
                    string user = Context.User.Identity.Name;

                    if (_userService.IsUserSignedInAsAdmin(Context.User))
                    {
                        user = "Admin";
                    }

                    await Clients.All.SendAsync("ReceiveMessage", user, message);
                }
            }
            else
            {
                await Clients.Caller.SendAsync("ReceiveMessage", "System", "You have been disconnected from the chat, reload the page to reconnect");
            }
        }
    }
}
