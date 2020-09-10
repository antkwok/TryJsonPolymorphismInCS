using System;
using System.Collections.Generic;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


namespace TryExtendJson
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            };
            
            
            var toSerialize = new Elements
            {
                new TextBox(),
                new CheckBox(),
                new SignaturePad(),
            };

            var settings = new JsonSerializerSettings
            {
                //TypeNameHandling = TypeNameHandling.Objects,
                //SerializationBinder = knownTypesBinder,
                ContractResolver = contractResolver,
            };
            
            settings.Converters.Add(JsonSubtypesConverterBuilder
                .Of(typeof(Element),"type")
                .RegisterSubtype(typeof(TextBox),"text")
                .RegisterSubtype(typeof(CheckBox),"check")
                .RegisterSubtype(typeof(SignaturePad),"sign")
                .SerializeDiscriminatorProperty()
                .Build()
            );
            
            var json = JsonConvert.SerializeObject(toSerialize, Formatting.Indented, settings);
            Console.WriteLine(json);

            var obj = JsonConvert.DeserializeObject<Elements>(json, settings);

            Console.ReadLine();
        }
    }
}