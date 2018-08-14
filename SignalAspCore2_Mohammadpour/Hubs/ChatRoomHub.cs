using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalAspCore2_Mohammadpour.Models;

namespace SignalAspCore2_Mohammadpour.Hubs
{
    public class MohammadpourChatRoomHub : Hub
    {
        DBMohammadpour db = new DBMohammadpour();
        public async Task F1(string username, string message, string receipient)
        {
            if (receipient == "")
                await Clients.All.SendAsync("F2", username, message);
            else
            {
                var p = db.TblSignalrusers.Where(x => x.Username.ToLower() == receipient.ToLower()).FirstOrDefault();
                if (p != null && p.ConnectionId != null)
                {
                    await Clients.Client(p.ConnectionId).SendAsync("F2", username, message);
                }
            }
        }
        public async Task RegisterUser(string username)
        {
            TblSignalrusers user =
                db.TblSignalrusers.Where(x => x.Username.ToLower() == username.ToLower()).FirstOrDefault();
            if (user == null)
            {
                user = new TblSignalrusers
                {
                    ConnectionId = Context.ConnectionId,
                    Username = username
                };
                db.TblSignalrusers.Add(user);
            }
            else
                user.ConnectionId = Context.ConnectionId;
            db.SaveChanges();
            List<string> users = db.TblSignalrusers.Where(x => x.ConnectionId != null)
                .Select(x => x.Username).ToList();
            await Clients.All.SendAsync("RefreshUserList", users);
            await Clients.All.SendAsync("NewUserRegister", username);
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var p = db.TblSignalrusers.Where(x => x.ConnectionId == Context.ConnectionId).FirstOrDefault();
            p.ConnectionId = null;
            db.SaveChanges();
            return base.OnDisconnectedAsync(exception);
        }
    }



}
