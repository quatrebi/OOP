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
        public static Regex busNumberPattern = new Regex(@"\d{4}\s\w{2}-[0-9]");
        public static Random rand = new Random(DateTime.Now.Millisecond);
        public static void Main(string[] args)
        {
            try
            {
                Reflector.InvokeMethods("Lab_12.Bus");
                Reflector.GetClassInformation("Lab_12.Bus");
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n\t{e.Message}\n{e.StackTrace}");
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

        private static void WriteToFile(string fileName, string str, FileMode mode = FileMode.Create)
        {
            FileStream fout = new FileStream(fileName, mode);
            byte[] data = Encoding.Default.GetBytes(str);
            fout.Write(data, 0, data.Length);
#if DEBUG
            Console.WriteLine(str);
#endif
            fout.Close();
        }

        private static string ReadFromFile(string fileName)
        {
            FileStream fin = new FileStream(fileName, FileMode.Open);
            byte[] data = new byte[fin.Length];
            fin.Read(data, 0, data.Length);
            fin.Close();
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
            Type t = GetObjectType(objName);
            var obj = Activator.CreateInstance(t);
            foreach (var args in from l in ReadFromFile(objName + "_args.txt").Split('\n')
                              select Regex.Split(l, @"\s*[->]\s*").Where(x => x != string.Empty).Select(x => Regex.Replace(x, @"[()\r]", "")))
            {
                MethodInfo method = t.GetMethod(args.LastOrDefault());
                object[] prms = (from p in args.FirstOrDefault().Split(',').Where(x => !x.Equals(string.Empty))
                                from pT in method.GetParameters().Select(x => x.ParameterType)
                                select Convert.ChangeType(p, pT)).ToArray();
                Console.WriteLine($"{args.LastOrDefault()}() -> {method.Invoke(obj, prms) ?? "void"}");
            }
        }

        public static void GetClassInformation(string objName)
        {
            Type t = GetObjectType(objName);

            WriteToFile(objName + ".txt", string.Join("\n", TableFormat(new string[] {
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
            WriteToFile(objName + ".txt", "\n\n Fields:\n\n\t" + string.Join("\n\t", GetClassFields(t.FullName)), FileMode.Append);
            WriteToFile(objName + ".txt", "\n\n Properties:\n\n\t" + string.Join("\n\t", GetClassProperties(t.FullName)), FileMode.Append);
            WriteToFile(objName + ".txt", "\n\n Methods:\n\n\t" + string.Join("\n\t", GetClassMethods(t.FullName)), FileMode.Append);
            WriteToFile(objName + ".txt", "\n\n Interfaces:\n\n\t" + string.Join("\n\t", GetClassInterfaces(t.FullName)), FileMode.Append);
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
