using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lab_11
{
    class Application
    {

        public static Regex busNumberPattern = new Regex(@"\d{4}\s\w{2}-[0-9]");
        public static Random rand = new Random(DateTime.Now.Millisecond);
        public static string[] months;
        const string sep = " : ";
        static void Main(string[] args)
        {
            string[] summer = { "June", "July", "August" };
            string[] autumn = { "September", "October", "November" };
            string[] winter = { "December", "January", "February" };
            string[] spring = { "March", "April", "May" };
            months = summer.Concat(autumn).Concat(winter).Concat(spring).ToArray();

            Console.Write("\n Введите длину строки: ");
            int n = Convert.ToInt32(Console.ReadLine());
            foreach (var s in from m in months where m.Length >= n select m)
                Console.Write(s + sep);

            Console.WriteLine("\n\n Вывод летних и зимних месяцев: ");
            foreach (var s in months.Where(x => months.Intersect(summer).Contains(x) || months.Intersect(winter).Contains(x)))
                Console.Write(s + sep);

            Console.WriteLine("\n\n Вывод месяцев в алфавитном порядке: ");
            Console.WriteLine(string.Join(sep, from m in months orderby m select m));

            Console.WriteLine("\n Месяца содержащие буквук 'u' и длиной не менее 4: ");
            Console.WriteLine(string.Join(sep, months.Where(x => x.Length >= 4 && x.Contains('u'))));

            List<Bus> buses = new List<Bus>();
            int count = rand.Next(5, 9);
            for (int i = 0; i < count; i++)
                buses.Add(new Bus());
            foreach (var b in from bus in buses orderby bus.BusNumber select bus)
                Console.Write(b + "\n");

            Console.Write("\n Введите номер маршрута: ");
            int wayNum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(string.Join("\n", from bus in buses where bus.WayNumber == wayNum select bus));

            Console.Write("\n Введите срок эксплуатации: ");
            int years = Convert.ToInt32(Console.ReadLine());
            foreach (var b in buses.Where(x => x.GetBusAge() >= years))
                Console.Write(b + "\n");

            var sortMileage = from bus in buses orderby bus.Mileage select bus;
            Console.WriteLine("\n Два первых и последних автобуса по пробегу: ");
            Console.WriteLine(string.Join("\n", sortMileage.Take(2)) + "\n\n" + string.Join("\n", sortMileage.Reverse().Take(2)));

            Console.Write("\n Введите месяц начала эксплуатации автобуса: ");
            int startMonth = Convert.ToInt32(Console.ReadLine());
            foreach (var b in buses.Where(x => x.StartDate.Month == startMonth))
                Console.Write(b + "\n");

            Console.WriteLine("\n Группировка автобусов по именам водителей: ");
            foreach (var group in from bus in buses group bus by bus.Driver.Firstname)
                Console.WriteLine(string.Join("\n", group) + "\n");

            Console.ReadKey();
        }
    }
}
