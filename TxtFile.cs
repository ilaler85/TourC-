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
        string path = @"C:\Users\vasil\source\repos\Tour\Info.txt";
        public List<Tour_Info> LoadFromFile()
        {
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                List<Tour_Info> list = new List<Tour_Info>();
                while (sr.Peek() > -1)
                {
                    string country = sr?.ReadLine();
                    string city = sr?.ReadLine();
                    string hotel = sr?.ReadLine();
                    DateTime dep_date = DateTime.Parse(sr?.ReadLine());
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

        public async void PrintToFile(List<Tour_Info> list)
        {
            string writePath = @"C:\Users\vasil\source\repos\Tour\Info.txt";
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    foreach(var item in list)
                    {
                        await sw.WriteLineAsync(item.Country);
                        await sw.WriteLineAsync(item.City);
                        await sw.WriteLineAsync(item.Hotel);
                        await sw.WriteLineAsync(item.Departure_Date.ToShortDateString().ToString());
                        await sw.WriteLineAsync(item.Return_Date.ToShortDateString().ToString());
                        await sw.WriteLineAsync(item.Price.ToString());
                        await sw.WriteLineAsync();
                    }
                    sw.Close();
                }
                Console.WriteLine("Запись выполнена");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
