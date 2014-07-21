using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Date_z_2_2
{
    class Date
    {
        private int _day = 0;
        private string _month = "";
        private int _year = 0;

        public Date(String month)
        {
            if (month.Length > 0) _month = month;
            else _month = "NoName";
        }
        public void Print()
        {
            Console.WriteLine(" {0,2} / {1,-8} / {2,4} г.", _day, _month, _year);
        }
        public string Month
        {
            set { _month = Convert.ToString(value); }
            get { return _month; }
        }
        public int Day
        {
            set { _day = Math.Abs(value); }
            get { return _day; }
        }
        public int Year
        {
            set { _year = Math.Abs(value); }
            get { return _year; }
        }      
    }
    class StaticDate
    {
        public static void PrintList(List<Date> Dates)
        {
            foreach (Date date in Dates) date.Print();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] name_month = { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
            //
            Random random = new Random();
            List<Date> dateList = new List<Date>
            {
                  new Date(name_month[random.Next(0,11)]) { Day = random.Next(1, 30), Year = random.Next(1981, 2014) },
                  new Date(name_month[random.Next(0,11)]) { Day = random.Next(1, 30), Year = random.Next(1981, 2014) },
                  new Date(name_month[random.Next(0,11)]) { Day = random.Next(1, 30), Year = random.Next(1981, 2014) },
                  new Date(name_month[random.Next(0,11)]) { Day = random.Next(1, 30), Year = random.Next(1981, 2014) },
                  new Date(name_month[random.Next(0,11)]) { Day = random.Next(1, 30), Year = random.Next(1981, 2014) },
                  new Date(name_month[random.Next(0,11)]) { Day = random.Next(1, 30), Year = random.Next(1981, 2014) },
                  new Date(name_month[random.Next(0,11)]) { Day = random.Next(1, 30), Year = random.Next(1981, 2014) },
                  new Date(name_month[random.Next(0,11)]) { Day = random.Next(1, 30), Year = random.Next(1981, 2014) },
                  new Date(name_month[random.Next(0,11)]) { Day = random.Next(1, 30), Year = random.Next(1981, 2014) },
                  // new Date(Console.ReadLine()) { Day = int.Parse(Console.ReadLine()), Year = int.Parse(Console.ReadLine()) },
              //    new Date(Console.ReadLine()) { Day = int.Parse(Console.ReadLine()), Year = int.Parse(Console.ReadLine()) },
                  //new Date(Console.ReadLine()) { Day = int.Parse(Console.ReadLine()), Year = int.Parse(Console.ReadLine()) },
                  //new Date(Console.ReadLine()) { Day = int.Parse(Console.ReadLine()), Year = int.Parse(Console.ReadLine()) },
                  //new Date(Console.ReadLine()) { Day = int.Parse(Console.ReadLine()), Year = int.Parse(Console.ReadLine()) }
            };
            //Вывод на экран исходного списка
            Console.WriteLine("Первоначальный список:");
            StaticDate.PrintList(dateList);
            //Сортировка в обратном направлении 
            Console.WriteLine("\nСписок в обратном порядке:");
            dateList.Reverse();
            StaticDate.PrintList(dateList);
            //Сортировка списка по выбранному критерию
            Console.Write("Введите критерий сортировки (День,Месяц,Год): ");
            switch (Console.ReadLine())
            {
                case "День":
                    Console.WriteLine("\nСписок по выбранному критерию:");
                    StaticDate.PrintList(dateList.OrderBy(h => h.Day).ToList());break;
                case "Месяц":
                    Console.WriteLine("\nСписок по выбранному критерию:");
                    StaticDate.PrintList(dateList.OrderBy(h => h.Month).ToList());break;
                case "Год":
                    Console.WriteLine("\nСписок по выбранному критерию:");
                    StaticDate.PrintList(dateList.OrderBy(h => h.Year).ToList());break;
                default: Console.WriteLine("Критерий задан неправильно"); break;
            }
            //Вставка нового элемента
            Console.WriteLine("Добавление нового элемента.Введите дата (Пример: 15 Июля 1998): ");
            string new_element = Console.ReadLine();
            DateTime dt = Convert.ToDateTime(new_element);           
            dateList.Add(new Date(name_month[dt.Month-1]) { Day = dt.Day, Year = dt.Year });
            Console.WriteLine("\nСписок с добавленным в конец элементом");
            StaticDate.PrintList(dateList);
            //Вставка элемента в заданную позицию
            Console.WriteLine("Введите номер позиции,в которую будет вставлен новый случайный элемент: ");
            int nata = int.Parse(Console.ReadLine())-1;
            dateList.Insert(nata, new Date(name_month[random.Next(0, 11)]) { Day = random.Next(1, 31), Year = random.Next(1981, 2014) });
            Console.WriteLine("\nСписок со вставленным элементом в указанную позицию");
            StaticDate.PrintList(dateList);
            //Удаление элемента списка, вставленный ранее
            dateList.RemoveAt(nata);
            Console.WriteLine("\nСписок с удаленным вставленным элементом");
            StaticDate.PrintList(dateList);
            //Поиск элемента списка
            Console.Write("Введите месяц для поиска : ");
            string a = Console.ReadLine();
            int index = dateList.FindIndex(h => h.Month == a);
            Console.WriteLine("\nНайденный элемент списка");
            dateList[index].Print(); 
            //Удаление списока 
            dateList.Clear();
            Console.WriteLine("\nПустой список");
            StaticDate.PrintList(dateList);
            Console.ReadKey();
        }
    }
}
