using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Tour
{
    class XmlFIle : IFileManager
    {
        public List<Tour_Info> LoadFromFile()
        {
            using (XmlReader reader = XmlReader.Create("XmlInfo.xml"))
            {
                XmlSerializer s = new XmlSerializer(typeof(List<Tour_Info>));
                return (List<Tour_Info>)s.Deserialize(reader);
            }
        }

        public void PrintToFile(List<Tour_Info> list)
        {
            using (XmlWriter writer = XmlWriter.Create("XmlInfo.xml"))
            {
                XmlSerializer s = new XmlSerializer(typeof(List<Tour_Info>));
                s.Serialize(writer, list);
                writer.Close();
            }
            Console.WriteLine("Запись выполнена");
        }
    }
}
