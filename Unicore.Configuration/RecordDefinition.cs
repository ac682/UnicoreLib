using System;
using System.Collections.Generic;
using System.Text;

namespace Unicore.Configuration
{
    public class RecordDefinition
    {
        public string Key { get; protected set; }

        public Type Type { get; protected set; }

        public RecordDefinition(string key, Type type)
        {
            Key = key;
            Type = type;
        }

        public override bool Equals(object obj)
        {
            return obj is RecordDefinition ? ((RecordDefinition)obj).Key == Key : false;
        }

        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }

        public static bool operator ==(RecordDefinition left, RecordDefinition right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(RecordDefinition left, RecordDefinition right)
        {
            return !left.Equals(right);
        }
    }
}
