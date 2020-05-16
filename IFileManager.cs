using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tour
{
    public interface IFileManager
    {
        void PrintToFile(List<Tour_Info> list, string fileName);
        List<Tour_Info> LoadFromFile(string fileName);
    }
}
