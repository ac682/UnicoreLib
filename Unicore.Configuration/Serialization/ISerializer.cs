using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Unicore.Configuration.Serialization
{
    public interface ISerializer
    {
        void Serialize(Stream writer, in IEnumerable<(string, object)> target);
        void Deserialize(Stream reader, in IEnumerable<RecordDefinition> pattern, out IEnumerable<(string, object)> target);
    }
}
