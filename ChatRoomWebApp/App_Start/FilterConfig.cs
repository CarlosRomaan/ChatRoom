using System.Web;
using System.Web.Mvc;

namespace ChatRoomWebApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new Filters.VerifySession());
            filters.Add(new Filters.VerifyUser());
        }
    }
}
