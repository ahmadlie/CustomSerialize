using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomSerializeDeserialize
{
    public static class CustomSD
    {
        public static string Serialize<T>(T myClass) where T : class
        {
            var typeName = typeof(T).Name;

            string jsonString = $"\"{typeName}\":" + " {\n";
            foreach (var prop in typeof(T).GetProperties())
            {
                var propValue = prop.GetValue(myClass).ToString();
                var propName = prop.Name;
                
                if (prop.PropertyType.Name == "String")
                {
                    jsonString += $"  \"{propName}\": \"{propValue}\"\n";
                }
                else
                {
                    jsonString += $"  \"{propName}\": {propValue}\n";

                }
            }
            return jsonString + "}";
        }

        public static TReturn Deserialize<TReturn>(string jsonString) where TReturn : class, new()
        {
            JObject jObject = JObject.Parse(jsonString);
            TReturn Root = new TReturn();

            foreach (var prop in jObject.Properties())
            {
                var targetProp = Root.GetType().GetProperty(prop.Name);
                if (targetProp != null)
                {
                    targetProp.SetValue(Root, prop.Value.ToObject(targetProp.PropertyType));
                }
            }
            return Root;
        }
    }
}
