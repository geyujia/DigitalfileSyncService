using System.IO.Compression;

namespace DigitalfileSyncService.Common
{
    /// <summary>
    /// 压缩文件
    /// </summary>
    public class ZipHelper
    {
        /// <summary>
        /// 压缩文件夹到ZIP文件
        /// </summary>
        /// <param name="sourceDirectory"></param>
        /// <param name="destinationZipFile"></param>
        public static void CreateZip(string sourceDirectory, string destinationZipFile)
        {
            if (Directory.Exists(sourceDirectory))
            {
                // 压缩文件夹到ZIP文件
                ZipFile.CreateFromDirectory(sourceDirectory, destinationZipFile);
            }
        }
    }
}
