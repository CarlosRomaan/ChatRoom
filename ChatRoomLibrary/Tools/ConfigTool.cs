using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using ChatRoomLibrary.Models.WS;
using Newtonsoft.Json;

namespace ChatRoomLibrary.Tools
{
    public class ConfigTool
    {
        public Reply oReply { get; set; }
        public ConfigTool()
        {
            oReply = new Reply();
        }

        public Reply Execute<T>(string url, string method, T objectRequest)
        {
            oReply.Result = 0;
            string result = "";
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = JsonConvert.SerializeObject(objectRequest);

                WebRequest request = WebRequest.Create(url);
                request.Method = method;
                request.PreAuthenticate = true;
                request.ContentType = "application/json;charset=utf-8";
                request.Timeout = 60000;

                using (var oStreamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    oStreamWriter.Write(json);
                    oStreamWriter.Flush();
                }

                var oHttpResponse = (HttpWebResponse)request.GetResponse();
                using (var oStreamReader = new StreamReader(oHttpResponse.GetResponseStream()))
                {
                    result = oStreamReader.ReadToEnd();
                }

                oReply = JsonConvert.DeserializeObject<Reply>(result);

            }
            catch (TimeoutException ex)
            {
                oReply.Message = "Servidor sin respuesta";
            }
            catch (Exception ex)
            {
                oReply.Message = "Ocurrio un error";
            }

            return oReply;
        }
    }
}
