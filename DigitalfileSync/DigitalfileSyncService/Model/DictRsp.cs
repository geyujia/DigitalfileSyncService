namespace DigitalfileSyncService.Model
{
    /// <summary>
    /// 字典表响应实体
    /// </summary>
    public class DictRsp
    {
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Value值
        /// </summary>
        public int dictKey { get; set; }
        /// <summary>
        /// 北京市建筑工程资料管理规程(DB11/T695-2017)
        /// </summary>
        public string kName { get; set; }
        /// <summary>
        /// 主表ID
        /// </summary>
        public int sortID { get; set; }
    }

}
