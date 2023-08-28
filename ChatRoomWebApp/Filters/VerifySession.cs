using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChatRoomWebApp.Controllers;

namespace ChatRoomWebApp.Filters
{
    public class VerifySession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);

                if (HttpContext.Current.Session["User"] == null)
                {
                    if (filterContext.Controller is UserController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("~/User/Login");
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }

    }
}