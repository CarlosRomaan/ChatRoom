using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoomLibrary.Models.Response
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string AccessToken { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        
    }
}
