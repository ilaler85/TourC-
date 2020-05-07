using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tour
{
    [Serializable]
    public class Tour_Info
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Hotel { get; set; }
        public DateTime Departure_Date { get; set; }
        public DateTime Return_Date { get; set; }
        public Double Price { get; set; }

        public Tour_Info(string country, string city, string hotel, DateTime dep_date, DateTime ret_date, double price)
        {
            this.Country = country;
            this.City = city;
            this.Hotel = hotel;
            this.Departure_Date = dep_date;
            this.Return_Date = ret_date;
            this.Price = price;
        }

        public Tour_Info() { }

        public override string ToString()
        {
            return String.Format("Страна: {0}, Город: {1}, Отель: {2},\nДата вылета: {3}, Дата возврата: {4}, Стоимость тура: {5} рублей\n", 
                Country, City, Hotel, Departure_Date.ToShortDateString().ToString(), Return_Date.ToShortDateString().ToString(), Price.ToString());
        }
    }
}
