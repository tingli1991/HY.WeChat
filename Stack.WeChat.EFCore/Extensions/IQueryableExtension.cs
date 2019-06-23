using Microsoft.EntityFrameworkCore;
using Stack.WeChat.DataContract.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Stack.WeChat.EFCore.Extensions
{
    /// <summary>
    /// 查询构造器扩展类
    /// </summary>
    public static class IQueryableExtension
    {
        #region ToPagerSource 分页查询
        /// <summary>
        /// 分页查询方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static DataResultList<T> ToPageList<T>(this IQueryable<T> query, int pageIndex, int pageSize) where T : class
        {
            DataResultList<T> result = new DataResultList<T>()
            {
                PageSize = pageSize,
                PageIndex = pageIndex,
                TotalCount = query.Count()
            };
            if (result.TotalCount > 0)
            {
                if (pageIndex == 1)
                {
                    query = query.Take(result.PageSize);
                }
                else
                {
                    query = query.Skip((result.PageIndex - 1) * result.PageSize).Take(result.PageSize);
                }
                result.DataList = query.ToList();
            }
            else
            {
                result.DataList = new List<T>();
            }
            return result;
        }

        /// <summary>
        /// 分页查询方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<DataResultList<T>> ToPageListAsync<T>(this IQueryable<T> query, int pageIndex, int pageSize) where T : class
        {
            DataResultList<T> result = new DataResultList<T>()
            {
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            result.TotalCount = await query.CountAsync();
            if (result.TotalCount > 0)
            {
                if (pageIndex == 1)
                {
                    query = query.Take(result.PageSize);
                }
                else
                {
                    query = query.Skip((result.PageIndex - 1) * result.PageSize).Take(result.PageSize);
                }
                result.DataList = await query.ToListAsync();
            }
            else
            {
                result.DataList = new List<T>();
            }
            return result;
        }
        #endregion
    }
}