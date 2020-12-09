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

        public static string[] GetLogs(string word)
        {
            FileStream fin = new FileStream(Filename, FileMode.Open);
            byte[] _data = new byte[fin.Length]; fin.Read(_data, 0, (int)fin.Length);
            fin.Close();
            string[] data = System.Text.Encoding.Default.GetString(_data).Split('\n');
            return (from line in data where line.Contains(word) select line).ToArray();
        }

        public static void ToLog(Type className, MethodInfo methodName, object[] args, object result)
        {
            FileStream file = new FileStream(CurrentDirectory + Filename, FileMode.Append);
            byte[] data = System.Text.Encoding.Default.GetBytes($"[{DateTime.Now.ToUniversalTime()}] {Environment.UserName} used {methodName?.Name}() with arguments = " +
                string.Join(",", args ?? new object[] { "null" }) + $" from {className?.FullName} --> {result?.ToString().Replace("\n", "+n") ?? "void"}\n");
            file.Write(data, 0, data.Length);
            file.Flush();
        }
    }
}
