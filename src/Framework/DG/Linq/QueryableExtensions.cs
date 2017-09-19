using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DG.Linq
{
    /// <summary>
    /// Query Linq lambda的扩展
    /// </summary>
    public static class QueryExtensions
    {
        #region 分页查询
        /// <summary>
        /// 分页 Skip(...).Take(...) 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="skipCount">pageSize*pageNo</param>
        /// <param name="pageSize"></param>
        /// <returns>hym create：2017-08-22</returns>
        public static IQueryable<T> PageBy<T>(this IQueryable<T> query, int skipCount, int pageSize)
        {
            if (query == null)
            {
                throw new ArgumentNullException("分页查询");
            }

            return query.Skip(skipCount).Take(pageSize);
        }

        /// <summary>
        /// 分页 Skip(...).Take(...) 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="skipCount">pageSize*pageNo</param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static IEnumerable<T> PageBy<T>(this IEnumerable<T> query, int skipCount, int pageSize)
        {
            if (query == null)
            {
                throw new ArgumentNullException("分页查询");
            }

            return query.Skip(skipCount).Take(pageSize);
        } 
        #endregion
        
        #region WhereIf
        /// <summary>
        /// 扩展条件查询语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate">where条件（lambda表达式）</param>
        /// <param name="condition">true=添加条件false=不添加条件</param>
        /// <returns>创建时间：2015-01-04</returns>
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> source, Expression<Func<T, bool>> predicate, bool condition)
        {
            return condition ? source.Where(predicate) : source;
        }
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> source, Expression<Func<T, int, bool>> predicate, bool condition)
        {
            return condition ? source.Where(predicate) : source;
        }
        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> source, Func<T, bool> predicate, bool condition)
        {
            return condition ? source.Where(predicate) : source;
        }
        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> source, Func<T, int, bool> predicate, bool condition)
        {
            return condition ? source.Where(predicate) : source;
        }
        #endregion

        #region DistinctBy
        /// <summary>
        /// List去重
        /// DistinctBy=》GroupBy
        /// </summary>
        /// <typeparam name="t"></typeparam>
        /// <param name="list"></param>
        /// <param name="propertySelector"></param>
        /// <returns></returns>
        public static IEnumerable<t> DistinctBy<t>(this IEnumerable<t> list, Func<t, object> propertySelector)
        {
            return list.GroupBy(propertySelector).Select(x => x.First());
        }
        #endregion
    }
}
