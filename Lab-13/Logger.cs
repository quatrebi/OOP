using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Lab_13
{
    public static class Logger
    {
        private static string m_fileName;
        private static string m_currentDirectory;
        public static FileStream file = new FileStream(CurrentDirectory + Filename, FileMode.Append);

        public static string CurrentDirectory
        {
            get
            {
                return m_currentDirectory ?? Directory.GetCurrentDirectory() + "\\";
            }
            set
            {
                m_currentDirectory = value;
            }
        }

        public static string Filename
        {
            get
            {
                return m_fileName ?? "log.txt";
            }
            set
            {
                m_fileName = value;
            }
        }

        public static string GetLog(string _date)
        {
            DateTime date = DateTime.Parse(_date);
            byte[] _data = null; file.Read(_data, 0, (int)file.Length);
            string[] data = System.Text.Encoding.Default.GetString(_data).Split('\n');
            return (from line in data
                    select DateTime.Parse(Regex.Split(line, @"[\[\]]").ElementAt(1))).Where(x => x == date).Select(x => x.ToString()).SingleOrDefault();
        }

        public static string[] GetLogs(string word)
        {
            byte[] _data = null; file.Read(_data, 0, (int)file.Length);
            string[] data = System.Text.Encoding.Default.GetString(_data).Split('\n');
            return (from line in data where line.Contains(word) select line).ToArray();
        }

        public static void ToLog(Type className, MethodInfo methodName, object[] args, object result)
        {
            byte[] data = System.Text.Encoding.Default.GetBytes($"[{DateTime.Now.ToUniversalTime()}] {Environment.UserName} used {methodName?.Name}() with arguments = " +
                string.Join(",", args ?? new object[] { "null" }) + $" from {className?.FullName} --> {result?.ToString().Replace("\n", "+n") ?? "void"}\n");
            file.Write(data, 0, data.Length);
            file.Flush();
        }

        public static void Close()
        {
            file.Close();
        }
    }
}
