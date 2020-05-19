using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tour
{
    class TxtFile : IFileManager
    {
        string path = @"C:\Users\vasil\source\repos\Tour\";
        public List<Tour_Info> LoadFromFile(string fileName)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path + fileName, System.Text.Encoding.Default))
                {
                    List<Tour_Info> list = new List<Tour_Info>();
                    while (sr.Peek() > -1)
                    {
                        string country = sr?.ReadLine();
                        string city = sr?.ReadLine();
                        string hotel = sr?.ReadLine();
                        DateTime dep_date = DateTime.Parse(sr?.ReadLine()); //сделать отдельную функцию ввода данных
                        DateTime ret_date = DateTime.Parse(sr?.ReadLine());
                        int price;
                        int.TryParse(sr?.ReadLine(), out price);
                        sr?.ReadLine();
                        Tour_Info tmp = new Tour_Info(country, city, hotel, dep_date, ret_date, price);
                        list.Add(tmp);
                    }
                    sr.Close();
                    return list;
                }
            }

            catch
            {
                throw new Exception("Такого файла не существует"); //жесткое исключение. Делал для проверки файла на существование, но для этого есть FileExists
            }

        }

        public void PrintToFile(List<Tour_Info> list, string fileName)
        {
            string writePath = @"C:\Users\vasil\source\repos\Tour\";
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath + fileName, false, System.Text.Encoding.Default))
                {
                    foreach(var item in list)
                    {
                        sw.WriteLine(item.Country);
                        sw.WriteLine(item.City);
                        sw.WriteLine(item.Hotel);
                        sw.WriteLine(item.Departure_Date.ToShortDateString().ToString()); //сделать отдельную функцию вывода данных
                        sw.WriteLine(item.Return_Date.ToShortDateString().ToString());
                        sw.WriteLine(item.Price.ToString());
                        sw.WriteLine();
                    }
                    sw.Close();
                }
                Console.WriteLine("Запись выполнена"); //обращения к консоли не должно быть отсюда
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
