using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChatRoomLibrary.Models.Response;

namespace ChatRoomWebApp.Controllers
{
    public class BaseController : Controller
    {
        public UserResponse userSession;
        
        protected void GetSession()
        {
            userSession = (UserResponse)Session["User"];
        }
    }
}