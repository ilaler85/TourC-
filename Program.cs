using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Tour_Info> list = ConsoleHelper.InputData();
            ConsoleHelper.PrintToConsole(list);
            int responce;
            do
            {
                Console.WriteLine("Что вы хотите сделать?" +
                    "\n1 - Добавить тур" +
                    "\n2 - Выполнить поиск туров по стране и сезону" +
                    "\n3 - Сохранить все данные в файл" +
                    "\n4 - Удалить данные о туре" +
                    "\n0 - Завершение работы");
                int.TryParse(Console.ReadLine(), out responce);
                switch (responce)
                {
                    case 1:
                        list = list.Concat(ConsoleHelper.InputData()).ToList();
                        ConsoleHelper.PrintToConsole(list);
                        break;
                    case 2:
                        List<Tour_Info> sortedList = SortTours(list);
                        ConsoleHelper.PrintToConsole(sortedList);
                        break;
                    case 3:
                        string name;
                        IFileManager file = ConsoleHelper.ChooseFile(out name);
                        file.PrintToFile(list, name);
                        break;
                    case 4:
                        Console.ReadLine();
                        Console.WriteLine("Выберите какой элемент удалить, начиная с 0");
                        int resp;
                        int.TryParse(Console.ReadLine(), out resp);
                        list.RemoveAt(resp);
                        Console.WriteLine("Удаление завершено");
                        Console.ReadLine();
                        ConsoleHelper.PrintToConsole(list);
                        break;
                }
            }
            while (responce != 0);                
        }

        static List<Tour_Info> SortTours(List<Tour_Info> list)
        {
            Console.WriteLine("Введите название страны");
            string country = Console.ReadLine();
            Console.WriteLine();
            List<int> season = ConsoleHelper.GetPeriod();
            Console.WriteLine();
            List<Tour_Info> sortedList = list.Where(cn => cn.Country == country && season.Contains(cn.Departure_Date.Month))
                                 .OrderBy(item => item.Price)
                                 .ThenBy(item => item.Departure_Date)
                                 .ThenBy(item => item.Return_Date.Subtract(item.Departure_Date))
                                 .ToList();
            return sortedList;
        }
    }
}
// Сощдание сохранение по расширению, создать класс фабрики, разобраться с интерфейсом, и желательно обработку листа в отдельный класс