using System;
using System.Collections.Generic;
using System.Linq;
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
            ForwardList list1 = new ForwardList(4);
            ForwardList list2 = new ForwardList(2);
            ForwardList list3 = list1 > list2;
            Console.WriteLine(list1);
            Console.WriteLine(list2);
            Console.WriteLine(list3);

            Console.ReadKey();
        }
    }
}
