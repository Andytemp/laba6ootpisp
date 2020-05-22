using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BasePlugins;
using System.IO;
using Newtonsoft.Json;
using System.Xml;
namespace XMLtoJSONdeprocessor
{
    public class XMLtoJSON:Deprocessor
    {
        public override string Deprocess(string FileToReadFrom)
        {
            string json = File.ReadAllText(FileToReadFrom);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(json);
            string jsonstring =  JsonConvert.SerializeXmlNode(doc);
            return unwrap(jsonstring);
        }
        private string unwrap(string jsonstring) {
            return jsonstring.Substring(8,jsonstring.Length-9);
        }
    }
}
