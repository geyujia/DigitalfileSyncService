using System.Numerics;

namespace DigitalfileSyncService.Model
{
    /// <summary>
    ///  WebApi返回结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Result<T> where T : class
    {

        /// <summary>
        /// 返回数据
        /// </summary>
        public T data { get; set; }

        /// <summary>
        /// 状态码
        /// </summary>
        public int statusCode { get; set; }
        /// <summary>
        /// 错误码
        /// </summary>
        public string errorCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string succeeded { get; set; }
        /// <summary>
        /// 错误描述
        /// </summary>
        public string errors { get; set; }
        /// <summary>
        ///     
        /// </summary>
        public string extras { get; set; }
        /// <summary>
        /// 时间戳
        /// </summary>
        public long timestamp { get; set; }
    }
}
