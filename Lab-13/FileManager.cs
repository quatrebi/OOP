using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_13
{
    public class FileManager
    {
        private DirInfo dir;
        private DiskInfo disk;

        public FileManager() : this(Directory.GetCurrentDirectory()) { }
        public FileManager(string path)
        {
            dir = new DirInfo(path);
            disk = new DiskInfo(path[0].ToString());
        }

        public void CopyExtsToDir(string ext, string pathFrom, string pathTo)
        {
            foreach (var file in new DirInfo(pathFrom.Replace('#', '.')).Directory.GetFiles())
                if (file.Extension == ext.Replace('#', '.'))
                    file.CopyTo(pathTo.Replace('#', '.') + file.Name, true);
        }

        public string GetDirectoryContents()
        {
            return string.Join("\n\t", $"[{dir.GetTimeOfCreation()}] Files amount: {dir.GetFilesAmount()}",
               string.Join("\n\t", dir.Directory.GetDirectories().Select(x => x.Name).ToArray()),
               string.Join("\n\t", dir.Directory.GetFiles().Select(x => x.Name).ToArray()));
        }

        public void CreateDirectory(string name) => dir.Directory.CreateSubdirectory(name);
        public void MoveDirectory(string pathFrom, string pathTo) => new DirInfo(pathFrom).Directory.MoveTo(pathTo);
        public void CreateZipDirectory(string zipName, string pathFrom) => ZipFile.CreateFromDirectory(pathFrom, zipName.Replace('#', '.'));
        public void ExtractZipDirectory(string zipName, string pathTo) => ZipFile.ExtractToDirectory(zipName.Replace('#', '.'), pathTo);

        public void RemoveFile(string name) => File.Delete(name.Replace('#', '.'));
        public void RenameFile(string oldPath, string newPath) => File.Move(oldPath.Replace('#', '.'), newPath.Replace('#', '.'));
        public void CopyFile(string oldPath, string newPath) => File.Copy(oldPath.Replace('#', '.'), newPath.Replace('#', '.'));
        public void WriteToFile(string name, string content = "")
        {
            string filename = dir.GetFullPath() + name.Replace('#', '.');
            StreamWriter sw = File.Exists(filename) ? new StreamWriter(filename) : File.CreateText(filename);
            sw.WriteLine(content);
            sw.Close();
        }
    }
}
