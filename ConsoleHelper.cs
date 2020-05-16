using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tour
{
    public class ConsoleHelper
    {
        public static void PrintToConsole(List<Tour_Info> list) //Печать листа 
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

        public static List<Tour_Info> InputData() // Выбор источника ввода и ввод данных
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

        public static List<Tour_Info> InputDataFromConsole() //Ввод данных из консоли
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

        public static void SetTour(List<Tour_Info> list) //Создание объекта Tour_Info
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

        public static Seasons GetSeason() //Определение времени года
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

        public static List<int> GetPeriod() //Получение листа месяцев давнного времени года
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

        public static IFileManager GetFile() //выбор типа файла для вывода информации
        {
            Console.WriteLine("Выберите тип файла? 1 - текстовый, 2 - бинарный, 3 - XML");
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
