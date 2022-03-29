using System;
using System.Collections.Generic;
using System.Linq;

namespace _018Join
{
    /// <summary>
    /// 连接扩展
    /// </summary>
    public static class JoinExtensions
    {
        /// <summary>
        /// 左连接
        /// </summary>
        /// <typeparam name="TSource">第一个序列中的元素的类型</typeparam>
        /// <typeparam name="TInner">第二个序列中的元素的类型</typeparam>
        /// <typeparam name="TKey">键选择器函数返回的键的类型</typeparam>
        /// <typeparam name="TResult">结果元素的类型</typeparam>
        /// <param name="source">第一个序列中的元素的类型</param>
        /// <param name="inner">第二个序列中的元素的类型</param>
        /// <param name="pk">用于从第一个序列的每个元素提取联接键的函数</param>
        /// <param name="fk">用于从第二个序列的每个元素提取联接键的函数</param>
        /// <param name="result">用于从两个匹配元素创建结果元素的函数</param>
        /// <returns></returns>
        public static IEnumerable<TResult> LeftJoin<TSource, TInner, TKey, TResult>(this IEnumerable<TSource> source,
                                                                                         IEnumerable<TInner> inner,
                                                                                         Func<TSource, TKey> pk,
                                                                                         Func<TInner, TKey> fk,
                                                                                         Func<TSource, TInner, TResult> result)
        {
            IEnumerable<TResult> _result = Enumerable.Empty<TResult>();

            _result = from s in source
                      join i in inner
                      on pk(s) equals fk(i) into joinData
                      from left in joinData.DefaultIfEmpty()
                      select result(s, left);

            return _result;
        }

        /// <summary>
        /// 右连接
        /// </summary>
        /// <typeparam name="TSource">第一个序列中的元素的类型</typeparam>
        /// <typeparam name="TInner">第二个序列中的元素的类型</typeparam>
        /// <typeparam name="TKey">键选择器函数返回的键的类型</typeparam>
        /// <typeparam name="TResult">结果元素的类型</typeparam>
        /// <param name="source">第一个序列中的元素的类型</param>
        /// <param name="inner">第二个序列中的元素的类型</param>
        /// <param name="pk">用于从第一个序列的每个元素提取联接键的函数</param>
        /// <param name="fk">用于从第二个序列的每个元素提取联接键的函数</param>
        /// <param name="result">用于从两个匹配元素创建结果元素的函数</param>
        /// <returns></returns>
        public static IEnumerable<TResult> RightJoin<TSource, TInner, TKey, TResult>(this IEnumerable<TSource> source,
                                                                                         IEnumerable<TInner> inner,
                                                                                         Func<TSource, TKey> pk,
                                                                                         Func<TInner, TKey> fk,
                                                                                         Func<TSource, TInner, TResult> result)
        {
            IEnumerable<TResult> _result = Enumerable.Empty<TResult>();

            _result = from i in inner
                      join s in source
                      on fk(i) equals pk(s) into joinData
                      from right in joinData.DefaultIfEmpty()
                      select result(right, i);

            return _result;
        }

        /// <summary>
        /// 全连接
        /// </summary>
        /// <typeparam name="TSource">第一个序列中的元素的类型</typeparam>
        /// <typeparam name="TInner">第二个序列中的元素的类型</typeparam>
        /// <typeparam name="TKey">键选择器函数返回的键的类型</typeparam>
        /// <typeparam name="TResult">结果元素的类型</typeparam>
        /// <param name="source">第一个序列中的元素的类型</param>
        /// <param name="inner">第二个序列中的元素的类型</param>
        /// <param name="pk">用于从第一个序列的每个元素提取联接键的函数</param>
        /// <param name="fk">用于从第二个序列的每个元素提取联接键的函数</param>
        /// <param name="result">用于从两个匹配元素创建结果元素的函数</param>
        /// <returns></returns>
        public static IEnumerable<TResult> FullOuterJoinJoin<TSource, TInner, TKey, TResult>(this IEnumerable<TSource> source,
                                                                                         IEnumerable<TInner> inner,
                                                                                         Func<TSource, TKey> pk,
                                                                                         Func<TInner, TKey> fk,
                                                                                         Func<TSource, TInner, TResult> result)
        {

            List<TResult> left = source.LeftJoin(inner, pk, fk, result).ToList();
            List<TResult> right = source.RightJoin(inner, pk, fk, result).ToList();
            return left.Union(right);

        }
    }
}
