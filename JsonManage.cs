using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlTranslate
{
    public class JsonManage
    {

        public static void Serialize<T>(T t, string fileName)
        {
            JsonSerializer serializer = new JsonSerializer();
            //serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;
            using (StreamWriter sw = new StreamWriter(@"c:\json.txt"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, t);
                // {"ExpiryDate":new Date(1230375600000),"Price":0}
            }
        }

        public static T Deserialize<T>(string fileName)
        {
            T t = default(T);

            return t;
        }
    }
}
