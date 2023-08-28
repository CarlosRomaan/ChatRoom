using ChatRoomWebApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChatRoomWebApp.Filters
{
    public class VerifyUser : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);

                if (HttpContext.Current.Session["User"] != null)
                {
                    if (filterContext.Controller is UserController == true)
                    {
                        filterContext.HttpContext.Response.Redirect("~/Chat/Index");
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}