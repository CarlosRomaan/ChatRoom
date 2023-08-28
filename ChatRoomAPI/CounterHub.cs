using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ChatRoomAPI.Models;

namespace ChatRoomAPI
{
    public class CounterHub : Hub
    {
        public override Task OnConnected()
        {
            Clients.All.enterUser();
            return base.OnConnected();
        }

        public void AddGroup(int idRoom)
        {
            Groups.Add(Context.ConnectionId, idRoom.ToString());
        }

        public void Send(int idRoom, string firstname, string lastname, int idUser, string message, string AccessToken)
        {
            if (VerifyToken(AccessToken))
            {

                var date = DateTime.Now.ToString();
                using (ChatRoomDBEntities db = new ChatRoomDBEntities())
                {
                    var oMessage = new ChatRoom_Messages();
                    oMessage.IdRoom = idRoom;
                    oMessage.Date_Created = DateTime.Now;
                    oMessage.IdUser = idUser;
                    oMessage.MessageText = message;
                    oMessage.IdState = 1;

                    db.ChatRoom_Messages.Add(oMessage);
                    db.SaveChanges();
                }
                Clients.All.sendChat(firstname, lastname, message, idUser, date);
            }
        }

        protected bool VerifyToken(string AccessToken)
        {
            using (ChatRoomDBEntities db = new ChatRoomDBEntities())
            {
                var oUser = db.ChatRoom_Users.Where(d => d.AccessToken == AccessToken).FirstOrDefault();

                if(oUser != null)
                {
                    return true;
                }
            }
            return false;
        }
    }
}