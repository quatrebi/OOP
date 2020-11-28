using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_9
{
    public class Application
    {
        public static Random rand;
        static void Main(string[] args)
        {
            rand = new Random(DateTime.Now.Millisecond);

            User user = new User()
            {
                name = "Quatre"
            };
            Software word = new Software(2019)
            {
                softName = "Office Word"
            };
            word.doUpgrade += (e) => Console.WriteLine(e.message);
            word.doWork += (e) => Console.WriteLine(e.message);

            user.Upgrade += word.doUpgrade;
            user.Work += word.doWork;

            user.DoWork(word);
            user.DoUpgrade(word);

            Software sai = new Software(125)
            {
                softName = "PaintTool SAI"
            };
            user.Upgrade += sai.doUpgrade;
            user.Work += sai.doWork;

            Console.WriteLine();
            user.DoUpgrade(sai);

            sai.doUpgrade += (e) => Console.WriteLine(e.message);
            sai.doWork += (e) => Console.WriteLine(e.message);

            user.DoWork(sai);
            user.DoUpgrade(sai);

            Console.WriteLine();
            Console.WriteLine(user);
            Console.WriteLine(word);
            Console.WriteLine(sai);

            Func<string, string>[] funcs = new Func<string, string>[]
                { (s) => s.ToUpper(), Shrink, ReplacePunctuationMarks, Shift, NotReadable };

            Console.Write("Введите строку: ");
            string inpt = Console.ReadLine();

            foreach (var func in funcs)
            {
                Console.WriteLine($"\tВызов метода через делегат - {func.Method.Name}");
                Console.WriteLine($" Результат: {inpt = func(inpt)}\n");
            }
            
            Console.ReadKey();
        }

        public static string Shift(string str)
        {
            char[] chs = str.ToCharArray();
            for (int i = 0; i < chs.Length; i++)
            {
                chs[i] = (char)(chs[i] + 1);
            }
            return new string(chs);
        }

        public static string ReplacePunctuationMarks(string str)
        {
            foreach (var ch in ".,?!;:")
                str = str.Replace(ch, (char)rand.Next(char.MaxValue));
            return str;
        }

        public static string NotReadable(string str) => new string(str.ToCharArray().Select((ch) => ch = (char)rand.Next(char.MaxValue)).ToArray());

        public static string Shrink(string str) => str.Replace(" ", "");
    }
}