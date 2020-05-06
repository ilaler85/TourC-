using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tour
{
    class FileProcessor
    {
        private readonly IFileManager manager;

        public FileProcessor (IFileManager manager)
        {
            this.manager = manager;
        }

        public void Print(List<Tour_Info> list)
        {
            manager.PrintToFile(list);
        }

        public List<Tour_Info> Load()
        {
            return manager.LoadFromFile();
        }

    }
}
