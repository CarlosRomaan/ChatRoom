using ChatRoomAPI.Models;
using ChatRoomLibrary.Models.Request;
using ChatRoomLibrary.Models.Response;
using ChatRoomLibrary.Models.WS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChatRoomAPI.Controllers
{
    public class LoginController : ApiController
    {
        [HttpPost]
        public Reply Login(LoginRequest model)
        {
            Reply oReply = new Reply();
            oReply.Result = 0;

            using (ChatRoomDBEntities db = new ChatRoomDBEntities())
            {
                var oUser = (from d in db.ChatRoom_Users
                             where d.Email == model.Email && d.Password == model.Password
                             select d).FirstOrDefault();

                if (oUser != null)
                {
                    string accessToken = Guid.NewGuid().ToString();

                    oUser.AccessToken = accessToken;
                    db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    UserResponse userResponse = new UserResponse();
                    userResponse.AccessToken = accessToken;
                    userResponse.Firstname = oUser.Firstname;
                    userResponse.Lastname = oUser.Lastname;
                    userResponse.Id = oUser.Id;

                    oReply.Result = 1;
                    oReply.Data = userResponse;
                }
                else
                {
                    oReply.Message = "Datos incorrectos, intenta de nuevo";
                }
            }
            return oReply;
        }
    }
}
