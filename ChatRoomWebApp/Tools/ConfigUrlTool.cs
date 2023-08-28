using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ChatRoomWebApp.Tools
{
    public class ConfigUrlTool
    {
        public static string UrlConfig
        {
            get
            {
                return ConfigurationManager.AppSettings["ConfigUrl"];
            }
        }

        public class Url
        {
            public static string Register
            {
                get
                {
                    return UrlConfig + "api/Register/";
                }
            }

            public static string Login
            {
                get
                {
                    return UrlConfig + "api/Login/";
                }
            }

            public static string Rooms
            {
                get
                {
                    return UrlConfig + "api/Room/";
                }
            }

            public static string Messages
            {
                get
                {
                    return UrlConfig + "api/Messages/";
                }
            }

            public static string SignalR
            {
                get
                {
                    return UrlConfig + "signalr/";
                }
            }

            public static string SignalRHub
            {
                get
                {
                    return UrlConfig + "signalr/hubs";
                }
            }
        }
    }
}