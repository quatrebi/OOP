using System;
using System.IO;

namespace Lab_13
{
    public class FileInfo
    {
        private System.IO.FileInfo m_fileInfo;

        public FileInfo(string fileName)
        {
            m_fileInfo = new System.IO.FileInfo(fileName);
        }

        public string GetFullPath() => m_fileInfo.FullName;
        public DateTime GetTimeOfCreation() => m_fileInfo.CreationTimeUtc;

        public override string ToString()
        {
            return $"{m_fileInfo.Name} [{m_fileInfo.Extension}] {m_fileInfo.Length} bytes";
        }
    }
}
