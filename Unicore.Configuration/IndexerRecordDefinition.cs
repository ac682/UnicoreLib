using System;
using System.Collections.Generic;
using System.Text;

namespace Unicore.Configuration
{
    public class IndexerRecordDefinition : RecordDefinition
    {
        public IndexerRecordDefinition():base("", null)
        {

        }

        public void Rename(string key)
        {
            Key = key;
        }
    }
}
