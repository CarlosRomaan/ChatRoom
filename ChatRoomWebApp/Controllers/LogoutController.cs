using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChatRoomWebApp.Controllers
{
    public class LogoutController : Controller
    {
        public ActionResult Logoff()
        {
            Session["User"] = null;
            return RedirectToAction("Login", "User");
        }
    }
}