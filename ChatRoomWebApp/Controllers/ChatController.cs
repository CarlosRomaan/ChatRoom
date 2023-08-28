using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChatRoomLibrary.Models.Request;
using ChatRoomLibrary.Models.Response;
using ChatRoomLibrary.Models.WS;
using ChatRoomLibrary.Tools;
using ChatRoomWebApp.Tools;
using Newtonsoft.Json;

namespace ChatRoomWebApp.Controllers
{
    public class ChatController : BaseController
    {
        
        public ActionResult Index()
        {
            GetSession();

            List<RoomsResponse> lst = new List<RoomsResponse>();

            SecurityRequest securityRequest = new SecurityRequest();
            securityRequest.AccessToken = userSession.AccessToken;

            ConfigTool configTool = new ConfigTool();
            Reply oReply =
                configTool.Execute<SecurityRequest>(ConfigUrlTool.Url.Rooms, "post", securityRequest);

            lst =
                JsonConvert.DeserializeObject<List<RoomsResponse>>(JsonConvert.SerializeObject(oReply.Data));
            
            return View(lst);
        }

        public ActionResult Room(int id)
        {
            GetSession();

            List<MessagesResponse> lst = new List<MessagesResponse>();
            
            MessagesRequest messagesRequest = new MessagesRequest();
            messagesRequest.AccessToken = userSession.AccessToken;
            messagesRequest.IdRoom = id;

            ConfigTool configTool = new ConfigTool();
            Reply oReply =
                configTool.Execute<MessagesRequest>(ConfigUrlTool.Url.Messages, "post", messagesRequest);

            lst =
                JsonConvert.DeserializeObject<List<MessagesResponse>>(JsonConvert.SerializeObject(oReply.Data));

            lst = lst.OrderBy(d => d.Date_Created).ToList();
            
            ViewBag.IdRoom = id;

            return View(lst);
        }
    }
}