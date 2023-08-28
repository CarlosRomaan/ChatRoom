using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoomLibrary.Models.Response
{
    public class MessagesResponse
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int IdUser { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Date_Created { get; set; }
        public int TypeMessage { get; set; }

    }
}
