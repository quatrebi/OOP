using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab_13
{
    internal static class Interpreter
    {
        public static string DefaultNamespace { get; set; }

        static Interpreter()
        {
            DefaultNamespace = "System";
        }
        public static object InvokeMethod(string str)
        {
            var splited = (from s in Regex.Split(str, @"[.(]")
                           select s.Replace(")", ""));

            string argsName = splited.LastOrDefault();
            string methodName = splited.ElementAt(splited.Count() - 2);
            string className = string.Join(".", splited.TakeWhile(x => x != methodName));

            Type type = Type.GetType(className, false, true) ?? Type.GetType($"{DefaultNamespace}.{className}", false, true);
            if (type == null) throw new Exception("Class type with this name cannot be found.");
            object obj = type.IsAbstract ? null : Activator.CreateInstance(type);
            KeyValuePair<Type, object>[] args = argsName.Split(',').Select(x =>
            {
                var kv = Regex.Split(x, @"\s*[=]\s*");
                var typeName = kv.FirstOrDefault().Replace("_", ".");
                Type t = Type.GetType(typeName, false, true) ?? Type.GetType($"{DefaultNamespace}.{typeName}", false, true);
                return new KeyValuePair<Type, object>(t, Convert.ChangeType(kv.LastOrDefault(), t ?? new object().GetType()));
            }).ToArray();
            if (args.Count() == 1 && args.FirstOrDefault().Key == null) args = null;
            MethodInfo method = type.GetMethod(methodName, args?.Select(x => x.Key).ToArray() ?? Type.EmptyTypes);
            object result = method?.Invoke(obj, args?.Select(x => x.Value).ToArray() ?? null);
            Logger.ToLog(type, method, args?.Select(x => x.Value).ToArray() ?? null, result);
            return result;
        }
    }
}
