using System;

namespace Lab_13
{
    public class Application
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string cmd = Console.ReadLine();
                Console.WriteLine(Interpreter.InvokeMethod(cmd));
            }
        }
    }
}
