using System;
using System.Collections.Generic;
using System.Text;
using Unicore.Configuration;

namespace Sample
{
    public class Config: ConfigBase
    {
        public string Test { get => GetValue<string>(TestDef); set => SetValue(TestDef, value); }
        private readonly RecordDefinition TestDef;
        public Config()
        {
            TestDef = Define<string>("editor.layz");
        }
    }
}
