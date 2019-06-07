using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq
{
    public static class Linq
    {
        /// <summary>
        ///  Projects each element of a sequence to an IEnumerable
        ///   and flattens the resulting sequences into one sequence.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static IEnumerable<TResult> SelectExt<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, TResult> selector)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (selector == null)
            {
                throw new ArgumentNullException("predicate");
            }
            foreach (TSource item in source)
            {
                yield return selector(item);
            }
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> WhereExt<TSource>(this IEnumerable<TSource> source, 
            Func<TSource, bool> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }
            foreach (TSource item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        /// <summary>
        /// Groups the elements of a sequence according to a specified key selector function.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public static IEnumerable<IGrouping<TKey, TSource>> GroupByExt<TSource, TKey>
            (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (keySelector == null)
            {
                throw new ArgumentNullException("keySelector");
            }

            var dict = new Dictionary<TKey, List<TSource>>();

            //Filling the dictionary.
            foreach (var x in source)
            {
                var key = keySelector(x);
                if (dict.Keys.Contains(key))
                {
                    dict[key].Add(x);
                }
                else
                {
                    dict.Add(key, new List<TSource> { x });
                }
            }

            foreach (var x in dict)
            {
                yield return new Grouping<TKey, TSource>(x.Key, x.Value);
            }
        }

        /// <summary>
        /// Returns a collection as a List.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static List<TSource> ToListExt<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            return new List<TSource>(source);
        }

        /// <summary>
        /// Creates a Dictionary from an IEnumerable according to a specified key selector function.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public static Dictionary<TKey, TSource> ToDictionaryExt<TSource, TKey>
            (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (keySelector == null)
            {
                throw new ArgumentNullException("keySelector");
            }

            Dictionary<TKey, TSource> dict = new Dictionary<TKey, TSource>();
            foreach (var item in source)
            {
                var key = keySelector(item);
                dict[key] = item;
            }
            return dict;
        }

        ///// <summary>
        ///// Sorts the elements of a sequence in ascending order according to a key.
        ///// </summary>
        ///// <typeparam name="TSource"></typeparam>
        ///// <typeparam name="TKey"></typeparam>
        ///// <param name="source"></param>
        ///// <param name="keySelector"></param>
        ///// <returns></returns>
        //public static IOrderedEnumerable<TSource> OrderByExt<TSource, TKey>
        //    (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        //{
        //    if (source == null)
        //    {
        //        throw new ArgumentNullException("source");
        //    }
        //    if (keySelector == null)
        //    {
        //        throw new ArgumentNullException("keySelector");
        //    }
        //    return new OrderedEnumerable<TSource>(source, new ProjectionComparer<TSource, TKey>(keySelector));
        //}
    }
}
