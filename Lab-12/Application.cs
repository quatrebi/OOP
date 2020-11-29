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
                Reflector.InvokeMethods("Lab_12.Reflector");
                Reflector.GetClassInformation("Lab_12.Reflector");
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n\t{e.Message}");
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
                throw new Exception("The type of a class cannot be determined by the class name alone or by the namespace name.");
            return Type.GetType(objName, false, true) ?? throw new Exception("Class type with this name cannot be found.");
        }

        private static void WriteToFile(FileStream fout, string str)
        {
            byte[] data = Encoding.Default.GetBytes(str);
            fout.Write(data, 0, data.Length);
#if DEBUG
            Console.WriteLine(str);
#endif
        }

        private static string ReadFromFile(FileStream fin)
        {
            byte[] data = new byte[fin.Length];
            fin.Read(data, 0, data.Length);
            return Encoding.Default.GetString(data);
        }

        private static string[] TableFormat(string[] args)
        {
            if (args.Length == 0) return new string[] { string.Empty };
            var tbls = (from s in args select s.Split(' ')).ToArray();
            for (int i = 0, mx = (from row in tbls select row[0].Length).Max(); i < tbls.GetLength(0); i++)
                tbls[i][0] = tbls[i][0].PadRight(mx + 6);
            return (from row in tbls select string.Join("", row)).ToArray();
        }

        public static void InvokeMethods(string objName)
        {
            FileStream fin = new FileStream(objName + "_args.txt", FileMode.Open);
            if (fin == null)
                throw new Exception("No argument file found for the method.");

            Type t = GetObjectType(objName);
            foreach (var x in from l in ReadFromFile(fin).Split('\n') select Regex.Split(l, @"\s*[->]\s*"))
            {
                t.GetMethod(x.LastOrDefault()).Invoke(Activator.CreateInstance(t), x.FirstOrDefault().Split(','));
            }
        }

        public static void GetClassInformation(string objName)
        {
            Type t = GetObjectType(objName);

            FileStream fout = new FileStream(objName + ".txt", FileMode.OpenOrCreate);
            WriteToFile(fout, string.Join("\n", TableFormat(new string[] {
                $"Namespace: {t.Namespace}",
                $"Name: {t.Name}\n",
                $"IsAbstract: {t.IsAbstract}",
                $"IsArray: {t.IsArray}",
                $"IsClass: {t.IsClass}",
                $"IsEnum: {t.IsEnum}",
                $"IsInterface: {t.IsInterface}",
                $"IsSealed: {t.IsSealed}",
                $"IsValueType: {t.IsValueType}",

            })));
            WriteToFile(fout, "\n\n Fields:\n\n\t" + string.Join("\n\t", GetClassFields(t.FullName)));
            WriteToFile(fout, "\n\n Properties:\n\n\t" + string.Join("\n\t", GetClassProperties(t.FullName)));
            WriteToFile(fout, "\n\n Methods:\n\n\t" + string.Join("\n\t", GetClassMethods(t.FullName)));
            WriteToFile(fout, "\n\n Interfaces:\n\n\t" + string.Join("\n\t", GetClassInterfaces(t.FullName)));
        }
        public static string[] GetClassFields(string objName) => TableFormat((from f in GetObjectType(objName).GetFields()
                                                                              select f.ToString()).ToArray());
        public static string[] GetClassProperties(string objName) => TableFormat((from p in GetObjectType(objName).GetProperties()
                                                                                  select p.ToString()).ToArray());
        public static string[] GetClassMethods(string objName) => TableFormat(
                (from ss in
                    from g in
                        from m in GetObjectType(objName).GetMethods()
                        group m by m.GetParameters().FirstOrDefault()?.ParameterType
                    select
                        (from m in g select m.ToString()).Append("")
                from s in ss
                select s).ToArray());
        public static string[] GetClassInterfaces(string objName) => TableFormat((from I in GetObjectType(objName).GetInterfaces()
                                                                                  select I.ToString()).ToArray());

        public static int field;
        public static bool Property { get; set; }
    }
}
