using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ChatRoomAPI.Models;
using ChatRoomLibrary.Models.Request;
using ChatRoomLibrary.Models.Response;
using ChatRoomLibrary.Models.WS;
using ChatRoomLibrary.Tools;

namespace ChatRoomAPI.Controllers
{
    public class RegisterController : ApiController
    {
        [HttpPost]
        public Reply Register([FromBody] UserRequest model)
        {
            Reply oReply = new Reply();

            try
            {
                using (ChatRoomDBEntities db = new ChatRoomDBEntities())
                {
                    ChatRoom_Users oUser = new ChatRoom_Users();
                    oUser.Email = model.Email;
                    oUser.Password = model.Password;
                    oUser.Firstname = model.Firstname;
                    oUser.Lastname = model.Lastname;
                    oUser.Date_Created = DateTime.Now;
                    oUser.IdState = 1;

                    db.ChatRoom_Users.Add(oUser);
                    db.SaveChanges();
                    oReply.Result = 1;
                }
            }
            catch(Exception ex)
            {
                oReply.Result = 0;
                oReply.Message = "Intenta de nuevo";
            }
            return oReply;
        }
    }
}
