namespace DigitalfileSyncService.Model
{
    /// <summary>
    /// 单个项目返回实体
    /// </summary>
    public class SingleProjectRsp
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 项目Id
        /// </summary>
        public Guid? ProjectId { get; set; }
        /// <summary>
        /// 单体名称
        /// </summary>
        public string? SingleName { get; set; }
    }
}
