using Lab_5;
using Lab_6.Interfaces;
using Lab_6.SportsEquipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Application
    {
        public static Random rand;

        static void Main(string[] args)
        {
            rand = new Random(DateTime.Now.Millisecond);
            Console.CursorVisible = false;

            Equipment[] equipments = new Equipment[4];
            equipments[0] = new Bar();
            equipments[1] = new BasketballBall();
            equipments[2] = new Bench();
            equipments[3] = new Mat();

            Table barTable = new Table(equipments[0]);
            barTable.GetTableDataFrom(equipments[0]);
            barTable.GetTableDataFrom(new Bar());
            barTable.GetTableDataFrom(new Bar());
            Console.WriteLine(barTable);

            Table basketballTable = new Table(equipments[1]);
            basketballTable.GetTableDataFrom(equipments[1]);
            basketballTable.GetTableDataFrom(new BasketballBall());
            basketballTable.GetTableDataFrom(new BasketballBall());
            basketballTable.ToString().WriteFromPosition((Console.WindowWidth / 2, 0));

            Table benchTable = new Table(equipments[2]);
            benchTable.GetTableDataFrom(equipments[2]);
            benchTable.GetTableDataFrom(new Bench());
            benchTable.GetTableDataFrom(new Bench());
            benchTable.ToString().WriteFromPosition((Console.WindowWidth / 2, Console.WindowHeight / 2));

            Table matTable = new Table(equipments[3]);
            matTable.GetTableDataFrom(equipments[3]);
            matTable.GetTableDataFrom(new Mat());
            matTable.GetTableDataFrom(new Mat());
            matTable.ToString().WriteFromPosition((0, Console.WindowHeight / 2));

            equipments[0].DoSomething();
            equipments[1].DoSomething();
            equipments[2].DoSomething();
            equipments[3].DoSomething();
            "Press any button to continue...".ToLog();
            Console.ReadKey();
            
            IBall ball = equipments[1] as BasketballBall;
            ball.DoKick();

            Printer printer = new Printer();
            foreach (var equipment in equipments)
            {
                printer.IAmPrinting(equipment);
            }

            "Press any button to continue...".ToLog();
            Console.ReadKey();

            (equipments[1] as BasketballBall).DoSomething();
            (equipments[1] as IBall).DoSomething();

            Console.ReadKey();
            Console.Clear();

            Gym gym = new Gym(400);
            while (gym.HasMoney)
            {
                Equipment eq = new BasketballBall();
                gym.AddItem(eq);
            }
            Console.WriteLine(gym.ToString());
            GymController gymc = new GymController(gym);
            gymc.Sort();
            Console.WriteLine(gym.ToString());
            Console.WriteLine("\tEnter cost range:");
            List<Equipment> founded = gymc.Find(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine($"\tResult [{founded.Count}]:");
            foreach (var item in founded)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadKey();
        }
    }

    public class Table
    {
        List<string[]> data;
        string[] captions;

        public Table(Equipment equip)
        {
            captions = equip.ToStaticString().Split('\t');
            data = new List<string[]>();
        }

        public void GetTableDataFrom(Equipment source)
        {
            data.Add(source.ToString().Split('\t'));
        }

        public override string ToString()
        {
            int[] colsSize = new int[captions.Length];
            for (int i = 0; i < colsSize.Length; i++)
            {
                colsSize[i] = int.MinValue;
            }
            foreach (var item in data)
            {
                for (int i = 0; i < item.Length; i++)
                {
                    colsSize[i] = Math.Max(colsSize[i], item[i].Length);
                }
            }

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < captions.Length; i++)
            {
                colsSize[i] = Math.Max(colsSize[i], captions[i].Length);
                result.Append($" {captions[i].PadRight(colsSize[i])} ");
            }
            result.AppendLine();

            for (int i = 0; i < data.Count; i++)
            {
                for (int j = 0; j < data[i].Length; j++)
                {
                    result.Append($" {data[i][j].PadRight(colsSize[j])} ");
                }
                result.AppendLine();
            }

            return result.ToString();
        }
    }

    public static class ExtensionMethods
    {
        private static int logSize = 0;
        private const int logMaxSize = 5;
        public static void ToLog(this string source)
        {
            source = $" - {source}";
            int buffTop = Console.CursorTop;
            Console.Write(source);
            Console.MoveBufferArea(Console.CursorLeft - source.Length, Console.CursorTop, Console.WindowWidth - 1, 1, 0, Console.WindowHeight - logMaxSize - 1 + logSize++);
            logSize %= (logMaxSize + 1);
            Console.SetCursorPosition(0, buffTop);
        }

        public static void WriteFromPosition(this string source, (int left, int top) target)
        {
            (int left, int top) buffCursor = (Console.CursorLeft, Console.CursorTop);
            Console.Write(source);
            string[] temp = source.Split('\n');
            Console.MoveBufferArea(buffCursor.left, buffCursor.top, temp.Max().Length, temp.Length, target.left, target.top);
            Console.SetCursorPosition(buffCursor.left, buffCursor.top);
        }
    }
}
