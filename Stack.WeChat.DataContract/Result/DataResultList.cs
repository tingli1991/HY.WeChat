using System;
using System.Collections.Generic;

namespace Stack.WeChat.DataContract.Result
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DataResultList<T>
    {
        /// <summary>
        /// 页码
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 分页条数
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 结果列表
        /// </summary>
        public List<T> DataList { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPage => (int)Math.Ceiling((decimal)TotalCount / PageSize);
    }
}