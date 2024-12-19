namespace DigitalfileSyncService.Model
{
    /// <summary>
    /// 返回工程信息
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 工程名称
        /// </summary>
        public string? ProjectName { get; set; }
    }
}
