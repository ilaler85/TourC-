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
            List<Tour_Info> list = InputData();
            PrintToConsole(list);
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
                        list = list.Concat(InputData()).ToList();
                        PrintToConsole(list);
                        break;
                    case 2:
                        List<Tour_Info> sortedList = SortTours(list);
                        PrintToConsole(sortedList);
                        break;
                    case 3:
                        IFileManager file = GetFile();
                        file.PrintToFile(list);
                        break;
                    case 4:
                        Console.ReadLine();
                        Console.WriteLine("Выберите какой элемент удалить, начиная с 0");
                        int resp;
                        int.TryParse(Console.ReadLine(), out resp);
                        list.RemoveAt(resp);
                        Console.WriteLine("Удаление завершено");
                        Console.ReadLine();
                        PrintToConsole(list);
                        break;
                }
            }
            while (responce != 0);                
        }

        static void PrintToConsole(List<Tour_Info> list)
        {
            int i = 0;
            foreach (var item in list)
            {
                Console.Write(String.Format("{0} - ", i));
                Console.WriteLine(item.ToString());
                i++;
            }
            Console.WriteLine(String.Format("Количество туров : {0}", i));
            Console.ReadLine();
            Console.WriteLine();
        }

        static List<Tour_Info> InputData()
        {
            Console.WriteLine("Выберите источник для ввода информации. 1 - консоль, 2 - текстовый файл, 3 - бинарный файл, 4 - XML файл");
            int response;
            int.TryParse(Console.ReadLine(), out response);
            switch (response)
            {
                case 1:
                    return InputDataFromConsole();
                case 2:
                    IFileManager txtFile = new TxtFile();
                    return txtFile.LoadFromFile();
                case 3:
                    IFileManager binFile = new BinaryFile();
                    return binFile.LoadFromFile();
                case 4:
                    IFileManager xmlFile = new XmlFIle();
                    return xmlFile.LoadFromFile();
                default:
                    throw new Exception("Введены неверные данные");
            }
        }

        static List<Tour_Info> InputDataFromConsole()
        {
            int response;
            List<Tour_Info> list = new List<Tour_Info>();
            do
            {
                Console.WriteLine("Введите информацию о туре");
                Console.WriteLine();
                SetTour(list);
                Console.WriteLine("Если хотите добавить еще один тур - нажмите любую клавишу, для отмены ввода нажмите 0");
                int.TryParse(Console.ReadLine(), out response);
            }
            while (response != 0);
            return list;
        }

        static void SetTour(List<Tour_Info> list)
        {
            Console.WriteLine("Введите страну");
            string country = Console.ReadLine();
            Console.WriteLine("Введите город");
            string city = Console.ReadLine();
            Console.WriteLine("Введите отель");
            string hotel = Console.ReadLine();
            Console.WriteLine("Введите дату вылета");
            DateTime dep_date = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Введите дату возврата");
            DateTime ret_date = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Введите цену");
            int price;
            int.TryParse(Console.ReadLine(), out price);
            Console.ReadLine();
            Tour_Info tmp = new Tour_Info(country, city, hotel, dep_date, ret_date, price);
            list.Add(tmp);
        }

        static List<Tour_Info> SortTours(List<Tour_Info> list)
        {
            Console.WriteLine("Введите название страны");
            string country = Console.ReadLine();
            Console.WriteLine("Введите название страны");
            List<int> season = GetPeriod();
            List<Tour_Info> sortedList = list.Where(cn => cn.Country == country && season.Contains(cn.Departure_Date.Month))
                                 .OrderBy(item => item.Price)
                                 .ThenBy(item => item.Departure_Date)
                                 .ThenBy(item => item.Return_Date.Subtract(item.Departure_Date))
                                 .Cast<Tour_Info>().ToList();
            return sortedList;
        }

        static Seasons GetSeason()
        {
            Console.WriteLine("Выберите сезон года 1 - Зима, 2 - Весна, 3 - Лето, 4 - Осень");
            int response;
            int.TryParse(Console.ReadLine(), out response);
            switch (response)
            {
                case 1:
                    return Seasons.Зима;
                case 2:
                    return Seasons.Весна;
                case 3:
                    return Seasons.Лето;
                case 4:
                    return Seasons.Осень;
                default:
                    throw new Exception("Введены неверные данные");
            }
        }

        static List<int> GetPeriod()
        {
            switch (GetSeason())
            {
                case Seasons.Зима:
                    List<int> winterList = new List<int>() { 1, 2, 12 };
                    return winterList;
                case Seasons.Весна:
                    List<int> springList = new List<int>() { 3, 4, 5 };
                    return springList;
                case Seasons.Лето:
                    List<int> summerList = new List<int>() { 6, 7, 8 };
                    return summerList;
                case Seasons.Осень:
                    List<int> autumnList = new List<int>() { 9, 10, 11 };
                    return autumnList;
                default:
                    throw new Exception("Введены неверные данные");
            }
        }

        static IFileManager GetFile()
        {
            Console.WriteLine("Выберите тип файла? 1 - текстовый, 2 - бинарный, 3 - XML" );
            string response = Console.ReadLine();
            if (response == "1")
            {
                IFileManager file = new TxtFile();
                return file;
            }

            if (response == "2")
            {
                IFileManager file = new BinaryFile();
                return file;
            }

            if (response == "3")
            {
                IFileManager file = new XmlFIle();
                return file;
            }
            else
                throw new Exception("Неверно введенные данные");
        }
    }
}
