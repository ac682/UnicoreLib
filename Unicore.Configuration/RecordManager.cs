using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Unicore.Configuration.Serialization;
using System.Linq;

namespace Unicore.Configuration
{
    public class RecordManager
    {
        Dictionary<RecordDefinition, object> records = new Dictionary<RecordDefinition, object>();

        private readonly IndexerRecordDefinition INDEXER = new IndexerRecordDefinition();

        public RecordDefinition Define<T>(string key, object defaultValue)
        {
            var res = new RecordDefinition(key, typeof(T));
            records.Add(res, defaultValue);
            return res;
        }

        public RecordDefinition Define<T>(string key)
        {
            return Define<T>(key, null);
        }

        public T GetValue<T>(RecordDefinition definition)
        {
            return (T)records[definition];
        }

        public object GetValue(string key)
        {
            return records[Index(key)];
        }

        public void SetValue(RecordDefinition definition, object value)
        {
            records[definition] = value;
        }

        public void SetValue(string key, object value)
        {
            records[Index(key)] = value;
        }

        public RecordDefinition Index(string key)
        {
            INDEXER.Rename(key);
            return INDEXER;
        }

        public void Serialize(Stream stream, SerializationConfiguration settings)
        {
            settings.Serializer.Serialize(stream, records.Select((x) => (x.Key.Key, x.Value)));
        }

        public void Deserialize(Stream stream, SerializationConfiguration settings)
        {
            IEnumerable<(string, object)> res;
            var keys = (IEnumerable<RecordDefinition>)records.Keys;
            settings.Serializer.Deserialize(stream, in keys,out res);
            ClearValues();
            foreach(var v in res.ToArray())
            {
                SetValue(v.Item1, v.Item2);
            }
        }

        public void ClearValues()
        {
            foreach(var k in records.Keys.ToArray())
            {
                records[k] = null;
            }
        }
    }
}
