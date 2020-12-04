using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab_13
{
    public class DirInfo
    {
        private DirectoryInfo m_directoryInfo;

        public DirectoryInfo Directory
        {
            get { return m_directoryInfo; }
        }

        public DirInfo(string path)
        {
            m_directoryInfo = new DirectoryInfo(path);
        }

        public int GetFilesAmount() => m_directoryInfo.GetFiles().Length;
        public DateTime GetTimeOfCreation() => m_directoryInfo.CreationTimeUtc;
        public int GetSubDirsAmount() => m_directoryInfo.GetDirectories().Length;
        public List<string> GetParentDirs() => m_directoryInfo.Parent.FullName.Split('\\').ToList();

        public string GetFullPath() => m_directoryInfo.FullName + "\\";
    }
}
