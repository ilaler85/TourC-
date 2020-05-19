using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tour
{
    static public class FileFactory
    {
        public static IFileManager GetFile(string exstension)
        {
            IFileManager file;
            switch (exstension)
            {
                case ".txt":
                    file = new TxtFile();
                    break;
                case ".bin":
                    file = new BinaryFile();
                    break;
                case ".xml":
                    file = new XmlFIle();
                    break;
                default: throw new Exception("Неверно указано имя файла");
            }
            return file;
        }
    }
}
