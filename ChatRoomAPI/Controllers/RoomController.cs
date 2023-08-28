using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ChatRoomLibrary.Models.Response;
using ChatRoomLibrary.Models.Request;
using ChatRoomLibrary.Models.WS;
using ChatRoomAPI.Models;

namespace ChatRoomAPI.Controllers
{
    public class RoomController : BaseController
    {
        [HttpPost]
        public Reply ListRoom([FromBody] SecurityRequest model)
        {
            Reply oReply = new Reply();
            oReply.Result = 1;

            if(!VerifyToken(model))
            {
                oReply.Message = "Método no permitido";
                oReply.Result = 0;
            }

            using (ChatRoomDBEntities db = new ChatRoomDBEntities())
            {
                List<RoomsResponse> lst = (from d in db.ChatRoom_Rooms
                                           where d.IdState == 1
                                           orderby d.Name
                                           select new RoomsResponse
                                           {
                                               Name = d.Name,
                                               Description = d.Description,
                                               Id = d.Id
                                           }).ToList();
                oReply.Result = 1;
                oReply.Data = lst;
            }

            return oReply;
        }
    }
}
