namespace DigitalfileSyncService.Model
{
    /// <summary>
    /// 文件信息
    /// </summary>
    public class ZipFileInfo
    {
        /// <summary>
        /// 文件名
        /// </summary>
        public string? fileName;
        /// <summary>
        /// 文件路径
        /// </summary>
        public string? filePath;
        /// <summary>
        /// 文件大小
        /// </summary>
        public int fileSize;
        /// <summary>
        /// 文件创建时间
        /// </summary>
        public DateTime creationTime;
        /// <summary>
        /// 文件最后修改时间
        /// </summary>
        public DateTime lastWriteTime;

        /// <summary>
        /// 文件类型
        /// </summary>
        public string? FileType
        {
            get
            {
                return Path.GetExtension(fileName);
            }
        }

    }
}
