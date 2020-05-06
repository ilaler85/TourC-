using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Tour
{
    class BinaryFile : IFileManager
    {
        public List<Tour_Info> LoadFromFile()
        {
            //string path = @"C:\Users\vasil\source\repos\Tour\BinInfo.txt";
            using (FileStream f = new FileStream("BinInfo.bin", FileMode.OpenOrCreate))
            {
                BinaryFormatter bf = new BinaryFormatter();
                return (List<Tour_Info>)bf.Deserialize(f);
            }
        }

        public void PrintToFile(List<Tour_Info> list)
        {
            using (FileStream f = new FileStream("BinInfo.bin", FileMode.OpenOrCreate))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(f, list);
                f.Close();
            }
            Console.WriteLine("Запись выполнена");
        }
    }
}
