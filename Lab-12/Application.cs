using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace Lab_12
{
    class Application
    {
        public static void Main(string[] args)
        {

            try
            {
                Reflector.GetAboutClass("Lab_12.Reflector");
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\t\t{e.Message}");
                Console.ResetColor();
            }
            Console.ReadKey();
        }
    }

    public static class Reflector
    {
        private static Regex regObjName = new Regex(@"^[a-z]\S+[.][a-z]\S+", RegexOptions.IgnoreCase);
        private static Type GetObjectType(string objName)
        {
            if (!regObjName.IsMatch(objName))
                throw new Exception("Type of class cannot be founed only by class name or name of namespace.");
            return Type.GetType(objName, false, true);
        }

        public static int field;
        public static bool Property { get; set; }
        public static void GetAboutClass(string objName)
        {
            Type t = GetObjectType(objName);

            FileStream fout = new FileStream(objName + ".txt", FileMode.OpenOrCreate);
            byte[] data = Encoding.Default.GetBytes(" Fields:\n" + string.Join("\n", t.GetFields().ToList()));
            fout.Write(data, 0, data.Count());
            data = Encoding.Default.GetBytes("\n\n Properties:\n" + string.Join("\n", t.GetProperties().ToList()));
            fout.Write(data, 0, data.Count());
            data = Encoding.Default.GetBytes("\n\n Methods:\n" + string.Join("\n", t.GetMethods().ToList()));
            fout.Write(data, 0, data.Count());
        }

        public static string[] GetClassMethods(string objName)
        {
            Type t = GetObjectType(objName);
            t.GetMethods().Aggregate((acc, cur) => cur.ToString().Replace(' ', '\t'))

        }
    }
}
