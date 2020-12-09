using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_14.SportsEquipment;

namespace Lab_14
{
    public class Application
    {
        public static Random rand;
        static void Main(string[] args)
        {
            void ColoredOutput(object obj, ConsoleColor fgc, ConsoleColor bgc)
            {
                Console.BackgroundColor = bgc;
                Console.ForegroundColor = fgc;
                Console.WriteLine(obj);
                Console.ResetColor();
            }

            rand = new Random(DateTime.Now.Millisecond);
            Gym gym = new Gym(250.0);
            while (gym.HasMoney)
            {
                gym.AddItem(new Bar());
                gym.AddItem(new Bench());
            }
            GymController gc = new GymController(gym);

            ColoredOutput("\nBinary serialization\n", ConsoleColor.Black, ConsoleColor.White);
            Serializator.SerializeToBinary(gc);
            ColoredOutput("Object for write to file -->", ConsoleColor.Black, ConsoleColor.White);
            Console.WriteLine(gc);
            Console.ReadKey();
            ColoredOutput("Object was readed from file <--", ConsoleColor.Black, ConsoleColor.White);
            gc = (GymController)Serializator.DeserializeFromBinary(gc.GetType().FullName + ".bin");
            Console.WriteLine(gc);

            //ColoredOutput("\nSOAP serialization\n", ConsoleColor.Black, ConsoleColor.White);
            //Serializator.SerializeToSOAP(gc);
            //ColoredOutput("Object for write to file -->", ConsoleColor.Black, ConsoleColor.White);
            //Console.WriteLine(gc);
            //Console.ReadKey();
            //ColoredOutput("Object was readed from file <--", ConsoleColor.Black, ConsoleColor.White);
            //gc = (GymController)Serializator.DeserializeFromSOAP(gc.GetType().FullName + ".soap");
            //Console.WriteLine(gc);

            //ColoredOutput("\nJSON serialization\n", ConsoleColor.Black, ConsoleColor.White);
            //Serializator.SerializeToJSON(gc);
            //ColoredOutput("Object for write to file -->", ConsoleColor.Black, ConsoleColor.White);
            //Console.WriteLine(gc);
            //Console.ReadKey();
            //ColoredOutput("Object was readed from file <--", ConsoleColor.Black, ConsoleColor.White);
            //gc = (GymController)Serializator.DeserializeFromJSON(gc.GetType().FullName + ".bin");
            //Console.WriteLine(gc);

            ColoredOutput("\nBinary serialization\n", ConsoleColor.Black, ConsoleColor.White);
            Serializator.SerializeToXML(gc);
            ColoredOutput("Object for write to file -->", ConsoleColor.Black, ConsoleColor.White);
            Console.WriteLine(gc);
            Console.ReadKey();
            ColoredOutput("Object was readed from file <--", ConsoleColor.Black, ConsoleColor.White);
            gc = (GymController)Serializator.DeserializeFromXML(gc.GetType().FullName + ".xml");
            Console.WriteLine(gc);

            Console.ReadKey();
        }
    }

    public static class Extensions
    {
        public static void ToLog(this string str) => Console.WriteLine(str);
    }
}
