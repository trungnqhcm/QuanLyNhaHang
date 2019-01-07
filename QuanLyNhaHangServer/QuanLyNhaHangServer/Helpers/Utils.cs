using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaHangServer.Helpers
{
    public static class Utils
    {
        public static JObject getJObjectResponseFromArray<T>(bool isSuccess, List<T> data)
        {
            var jObject = (dynamic)new JObject();
            jObject.Successful = isSuccess;
            jObject.Data = new JArray();
            foreach (var item in data)
            {
                jObject.Data.Add(JObject.Parse(JsonConvert.SerializeObject(item, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                })));
            }
            return jObject;
        }

        //private static JObject parseArray<T>(List<T> data)
        //{
        //    var jObject = (dynamic)new JObject();
        //    jObject.Data = new JArray();
        //    foreach (var item in data)
        //    {
        //        jObject.Data.Add(JObject.Parse(JsonConvert.SerializeObject(item)));
        //    }
        //    return jObject;
        //}

        public static JObject getJObjectResponseFromObject(bool isSuccess, object data, string error = "")
        {
            var jObject = (dynamic)new JObject();
            jObject.Successful = isSuccess;
            jObject.Data = JObject.Parse(JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }));
            jObject.Error = error;
            return jObject;
        }
    }
}
