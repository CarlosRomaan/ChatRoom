using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoomLibrary.Models.WS
{
    public class Reply
    {
        public string Message { get; set; }
        public int Result { get; set; } 
        public object Data { get; set; }
    }
}
