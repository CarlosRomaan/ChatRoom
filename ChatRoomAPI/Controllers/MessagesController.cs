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

namespace ChatRoomAPI.Controllers
{
    public class MessagesController : BaseController
    {
        [HttpPost]
        public Reply Get([FromBody] MessagesRequest model)
        {
            Reply oReply = new Reply();
            oReply.Result = 0;

            if(!VerifyToken(model))
            {
                oReply.Message = "Método no permitido";
                return oReply;
            }

            try
            {
                using (ChatRoomDBEntities db = new ChatRoomDBEntities())
                {
                    List<MessagesResponse> lst = (from d in db.ChatRoom_Messages.ToList()
                                                  where d.IdState == 1 && d.IdRoom == model.IdRoom
                                                  orderby d.Date_Created descending
                                                  select new MessagesResponse
                                                  {
                                                      Message = d.MessageText,
                                                      Id = d.Id,
                                                      IdUser = d.IdUser,
                                                      Firstname = d.ChatRoom_Users.Firstname,
                                                      Lastname = d.ChatRoom_Users.Lastname,
                                                      Date_Created = d.Date_Created,
                                                      TypeMessage = (
                                                                     new Func<int>(
                                                                         () =>
                                                                         {
                                                                             try
                                                                             {
                                                                                 if (d.IdUser == userSession.Id)
                                                                                 {
                                                                                     return 1;
                                                                                 }
                                                                                 else
                                                                                 {
                                                                                     return 2;
                                                                                 }
                                                                             }
                                                                             catch
                                                                             {
                                                                                 return 2;
                                                                             }
                                                                         }
                                                                         )()
                                                      )
                                                  }).Take(20).ToList();
                    oReply.Result = 1;
                    oReply.Data = lst;
                }
            }

            catch(Exception ex)
            {
                oReply.Message = "Ocurrió un problema";
            }

            return oReply;
        }
    }
}
