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

            Type type = Type.GetType(className, false, true);
            object obj = type.IsAbstract ? null : Activator.CreateInstance(type);
            KeyValuePair<Type, object>[] args = argsName.Split(',').Select(x =>
            {
                var kv = x.Split(':');
                Type t = Type.GetType(kv.FirstOrDefault().Replace("_", "."));
                return new KeyValuePair<Type, object>(t, Convert.ChangeType(kv.LastOrDefault(), t));
            }).ToArray();
            MethodInfo method = type.GetMethod(methodName, args.Select(x => x.Key).ToArray());
            return method.Invoke(obj, args.Select(x => x.Value).ToArray());
        }
    }
}
