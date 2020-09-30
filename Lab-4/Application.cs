using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
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
            ForwardList.Owner owner = new ForwardList.Owner(DateTime.Now.Millisecond)
            {
                author = "QuatreB",
                company = "Software Crew"
            };
            Console.WriteLine($"\t\tWho am I?\n\t\t{owner}\n");

            ForwardList a = new ForwardList(rand.Next(2, 5));
            ForwardList b = new ForwardList(rand.Next(2, 5));

            Console.WriteLine($" [A]\tOwner: {a.owner}\tCreation date: {a.creationDate}\n" + a);
            Console.WriteLine($" [B]\tOwner: {b.owner}\tCreation date: {b.creationDate}\n" + b);
            Console.WriteLine();

            Console.WriteLine(" [!A] Инверсия:\n" + !a);
            Console.WriteLine(" [!B] Инверсия:\n" + !b);

            Console.WriteLine(" [A + B] Объединение:\n" + (a + b));
            Console.WriteLine(" [A < B] Присоединение:\n" + (a < b));
            Console.WriteLine(" [A > B] Присоединение:\n" + (a > b));
            Console.WriteLine(" [A == B] Сравнение:\n\t" + (a == b));
            Console.WriteLine(" [A != B] Сравнение:\n\t" + (a != b));


            Console.ReadKey();
        }
    }

    public static class StatisticOperation
    {
        public static long Sum(this ForwardList obj)
        {
            long result = 0;
            Iterator cur = obj.First;
            while (cur != null)
            {
                result += cur.Value;
                cur = cur.Next;
            }
            return result;
        }

        public static long MaxMinDiff(this ForwardList obj)
        {
            long max = long.MinValue, min = long.MaxValue;
            Iterator cur = obj.First;
            while (cur != null)
            {
                max = Math.Max(max, cur.Value);
                min = Math.Min(min, cur.Value);
                cur = cur.Next;
            }
            return max - min;
        }
        public static long Count(this ForwardList obj)
        {
            int result = 0;
            Iterator cur = obj.First;
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
