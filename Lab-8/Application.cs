using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{ 
    class Application
    {
        public static readonly Random rand;

        static Application()
        {
            rand = new Random(DateTime.Now.Millisecond);
        }

        static void Main(string[] args)
        {
            ForwardList<int>.Owner owner = new ForwardList<int>.Owner(DateTime.Now.Millisecond)
            {
                author = "QuatreB",
                company = "Software Crew"
            };
            Console.WriteLine($"\t\tWho am I?\n\t\t{owner}\n");

            ForwardList<int> a = new ForwardList<int>(rand.Next(2, 5));
            ForwardList<int> b = new ForwardList<int>(rand.Next(2, 5));

            try
            {
                Console.WriteLine($" [A]\tOwner: {a.owner}\tCreation date: {a.creationDate}\n" + a);
                Console.WriteLine($" [B]\tOwner: {b.owner}\tCreation date: {b.creationDate}\n" + b);
                Console.WriteLine();
                
                Console.WriteLine(" [A + B] Объединение:\n" + (a + b));
                Console.WriteLine(" [A < B] Присоединение:\n" + (a < b));
                Console.WriteLine(" [A > B] Присоединение:\n" + (a > b));
                Console.WriteLine(" [A == B] Сравнение:\n\t" + (a == b));
                Console.WriteLine(" [A != B] Сравнение:\n\t" + (a != b));

                Console.WriteLine(" [!A] Инверсия:\n" + !a);
                Console.WriteLine(" [!B] Инверсия:\n" + !b);
            }
            catch (InvalidCastException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Data);
                Console.WriteLine(ex.StackTrace);
                Console.ForegroundColor = ConsoleColor.White;
            }

            ForwardList<Equipment> c = new ForwardList<Equipment>()
            {
                First = new Iterator<Equipment>
                {
                    Value = new Equipment()
                    {
                        somethingField = 10,
                        SomethingProperty = "smth"
                    },
                },
            };
            c.Insert(new Equipment()
            {
                SomethingProperty = "property"
            });
            c.View();
            c.First.Value.SomethingMethod();
            Console.WriteLine();

            try
            {
                a.Insert(228); b.Insert(228);
                a.Insert(337); b.Insert(337);
                a.View(); b.View();
                Console.WriteLine();
                a.Extract(228); b.Extract(337);
                a.View(); b.View();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            try
            {
                a.OutputToFile(new FileStream(Directory.GetCurrentDirectory() + @"\a.txt", FileMode.Create));
                b.InputFromFile(new FileStream(Directory.GetCurrentDirectory() + @"\a.txt", FileMode.Open));
            }
            finally
            {
                Console.WriteLine();
                a.View(); b.View();
                Console.WriteLine("[finally] Application was stopped!");
            }

            Console.ReadKey();
        }
    }

    public static class StatisticOperation
    {
        public static long Sum(this ForwardList<int> obj)
        {
            long result = 0;
            Iterator<int> cur = obj.First;
            while (cur != null)
            {
                result += cur.Value;
                cur = cur.Next;
            }
            return result;
        }

        public static long MaxMinDiff(this ForwardList<int> obj)
        {
            long max = long.MinValue, min = long.MaxValue;
            Iterator<int> cur = obj.First;
            while (cur != null)
            {
                max = Math.Max(max, cur.Value);
                min = Math.Min(min, cur.Value);
                cur = cur.Next;
            }
            return max - min;
        }
        public static long Count(this ForwardList<int> obj)
        {
            int result = 0;
            Iterator<int> cur = obj.First;
            while (cur != null)
            {
                result++;
                cur = cur.Next;
            }
            return result;
        }

        public static string Truncate(this string obj, int length)
        {
            if (length < obj.Length) return obj.Substring(0, length);
            else return obj.PadRight(length, '.');
        }

    }
}
