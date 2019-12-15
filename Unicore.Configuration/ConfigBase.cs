using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Unicore.Configuration.Serialization;

namespace Unicore.Configuration
{
    public class ConfigBase
    {
        public readonly RecordManager RecordSet = new RecordManager();

        protected RecordDefinition Define<T>(string key, object defaultValue) => RecordSet.Define<T>(key, defaultValue);
        protected RecordDefinition Define<T>(string key) => RecordSet.Define<T>(key);
        protected T GetValue<T>(RecordDefinition definition) => RecordSet.GetValue<T>(definition);
        protected void SetValue(RecordDefinition definition, object value) => RecordSet.SetValue(definition, value);

        public void Load(string fileName, SerializationConfiguration settings)
        {
            var stream = File.OpenRead(fileName);
            RecordSet.Deserialize(stream, settings);
            stream.Close();
        }

        public void Save(string fileName, SerializationConfiguration settings)
        {
            var stream = File.Open(fileName, FileMode.Create);
            RecordSet.Serialize(stream, settings);
            stream.Close();
        }
    }
}
