using System;
using System.Collections.Generic;

namespace Stack.WeChat.MP.Extensions
{
    /// <summary>
    /// Linq的lambda表达式去重扩展
    /// </summary>
    public static class DistinctExtensions
    {
        /// <summary>
        /// 去重
        /// </summary>
        /// <typeparam name="TSource">源对象</typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="source">源数据</param>
        /// <param name="keySelector">去重得字段</param>
        /// <returns></returns>
        public static IEnumerable<TSource> Distinct<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
    }
}