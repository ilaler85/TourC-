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
        public List<Tour_Info> LoadFromFile(string fileName)
        {
            try
            {
                using (FileStream f = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    return (List<Tour_Info>)bf.Deserialize(f);
                }
            }
            
            catch
            {
                throw new Exception("Такого файла не существует или файл пустой");//жесткое исключение. Делал для проверки файла на существование, но для этого есть FileExists
            }
        }

        public void PrintToFile(List<Tour_Info> list, string fileName)
        {
            using (FileStream f = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(f, list);
                f.Close();
            }
            Console.WriteLine("Запись выполнена");//обращения к консоли не должно быть отсюда
        }
    }
}
