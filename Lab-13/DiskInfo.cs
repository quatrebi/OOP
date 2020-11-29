using System;
using System.IO;

namespace Lab_13
{
    public class DiskInfo
    {
        private DriveInfo m_driveInfo;

        public DiskInfo(string diskName)
        {
            m_driveInfo = new DriveInfo(diskName);
        }
        public long GetAvailableFreeSpace() => m_driveInfo.AvailableFreeSpace;
        public string GetFileSystemFormat() => m_driveInfo.DriveFormat;

        public override string ToString()
        {
            return $"[{m_driveInfo.VolumeLabel}] {m_driveInfo.Name} {GetAvailableFreeSpace()} / {m_driveInfo.TotalSize} bytes";
        }
    }
}
