using System;
using Shapes;
using Drawer;
using Newtonsoft.Json;
using System.IO;
namespace Serializer
{
    public class Serializer
    {
        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        };

        public string Serialize(ShapesList shapes) {
            string jsonstring = JsonConvert.SerializeObject(shapes,Formatting.Indented, settings);
            return jsonstring;
        }

        public ShapesList Deserialize(string jsonstring){
            ShapesList Slist = JsonConvert.DeserializeObject<ShapesList>(jsonstring, settings);
            return Slist;
        }
        public Serializer()
        {

        }


    }
}