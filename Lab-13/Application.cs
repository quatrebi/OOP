using System;
using System.IO;
using System.Security.Principal;

namespace Lab_13
{
    public class Application
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join("\n", Logger.GetLog("09.12.2020")));
            //Console.WriteLine(string.Join("\n", Logger.GetLogs("CopyFile")));
            Console.Title = "[CFM] Console File Manager";
            string cmd = string.Empty;
            while (cmd != "Exit()")
            {
                Console.ForegroundColor = new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator) ? ConsoleColor.Green : ConsoleColor.DarkGreen;
                Console.Write($"{Environment.UserName}@{Environment.UserDomainName}:");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write($"~{Directory.GetCurrentDirectory().Replace(Environment.CurrentDirectory, "")}");
                Console.ResetColor(); Console.Write("$ ");
                cmd = Console.ReadLine();
                try
                {
                    Console.WriteLine(Interpreter.InvokeMethod(cmd));
                }
                finally { }
                //catch (Exception e)
                //{
                //    Console.ForegroundColor = ConsoleColor.Red;
                //    Console.WriteLine($"[ERROR] {e.Message}\n\n{e.StackTrace}\n");
                //    Console.ResetColor();
                //}
            }
        }
    }
}
