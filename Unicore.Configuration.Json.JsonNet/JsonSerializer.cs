using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using Unicore.Configuration.Serialization;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Unicore.Configuration.Json.JsonNet
{
    public class JsonSerializer : ISerializer
    {
        public void Deserialize(Stream reader, in IEnumerable<RecordDefinition> pattern, out IEnumerable<(string, object)> result)
        {
            StreamReader stream = new StreamReader(reader);
            string json = stream.ReadToEnd();
            JObject obj = (JObject)JsonConvert.DeserializeObject(json);
            result = pattern.Select(x => (x.Key, obj[x.Key]?.ToObject(x.Type))).Where(x => x.Item2 !=null);
            stream.Close();
        }

        public void Serialize(Stream writer, in IEnumerable<(string, object)> tar)
        {
            StreamWriter stream = new StreamWriter(writer);
            stream.Write(JsonConvert.SerializeObject(tar.ToDictionary(x => x.Item1, x => x.Item2)));
            stream.Close();
        }
    }
}
