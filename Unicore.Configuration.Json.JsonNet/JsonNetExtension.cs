using System;
using System.Collections.Generic;
using System.Text;
using Unicore.Configuration.Serialization;

namespace Unicore.Configuration.Json.JsonNet
{
    public static class JsonNetExtension
    {
        public static void UseJsonNetSerializer(this SerializationConfiguration settings)
        {
            settings.Serializer = new JsonSerializer();
        }
    }
}
