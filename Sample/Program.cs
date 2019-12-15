using System;
using System.IO;
using Unicore.Configuration.Json.JsonNet;
using Unicore.Configuration.Serialization;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Random rnd = new Random();
            Config config = new Config();
            var settings = new SerializationConfiguration();
            settings.UseJsonNetSerializer();
            config.Load(Path.Combine(Environment.CurrentDirectory, "a.json"), settings);
            Console.WriteLine(config.Test);
            config.Test = rnd.Next().ToString();
            config.Save(Path.Combine(Environment.CurrentDirectory, "a.json"), settings);
            Console.WriteLine(config.Test);
            Console.ReadLine();
        }
    }
}
