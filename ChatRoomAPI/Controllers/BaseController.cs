using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ChatRoomLibrary.Models.Response;
using ChatRoomLibrary.Models.Request;
using ChatRoomAPI.Models;

namespace ChatRoomAPI.Controllers
{
    public class BaseController : ApiController
    {
        public UserResponse userSession;

        protected bool VerifyToken(SecurityRequest model)
        {
            using (ChatRoomDBEntities db = new ChatRoomDBEntities())
            {
                var oUser = db.ChatRoom_Users.Where(d => d.AccessToken == model.AccessToken).FirstOrDefault();

                if (oUser != null)
                {
                    userSession = new UserResponse();

                    userSession.AccessToken = oUser.AccessToken;
                    userSession.Firstname = oUser.Firstname;
                    userSession.Lastname = oUser.Lastname;
                    userSession.Id = oUser.Id;
                    return true;
                }
            }
            return false;
        }
    }
}
