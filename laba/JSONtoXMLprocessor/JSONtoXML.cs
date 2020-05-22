using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BasePlugins;
using System.IO;
using Newtonsoft.Json;
using System.Xml;
namespace JSONtoXMLprocessor
{
    public class JSONtoXML:Processor
    {
        public override void Process(string value, string FileToWrite)
        {
            XmlDocument doc = (XmlDocument)JsonConvert.DeserializeXmlNode(wrapjson(value));
            doc.Save(FileToWrite);
        }
        private string wrapjson(string jsonstring) {
            return "{\r\n  \"root\":" + jsonstring + "\r\n}";
        }
    }
}
