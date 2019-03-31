using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Homework_25_03
{
    public class JsonToXml
    {
        public void WriteToFile(string path, string jsonStr)
        {
            string xmlStr = Convert(jsonStr);
            XmlDocument xmlDocument = new XmlDocument();
            if (!File.Exists(path))
            {
                using (FileStream fileStream = File.Create(path))
                {
                    byte[] bytes = System.Text.Encoding.Default.GetBytes(xmlStr);
                    fileStream.Write(bytes, 0, bytes.Length);
                }
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(path, true))
                {
                    streamWriter.Write(xmlStr);
                }
            }
        }
        public string Convert(string jsonStr)
        {
            XNode node = JsonConvert.DeserializeXNode(jsonStr, "root");
            return node.ToString();
        }
    }
}
