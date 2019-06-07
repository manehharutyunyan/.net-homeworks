//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;

//namespace Linq
//{
//    internal class OrderedEnumerable<TSource> : IOrderedEnumerable<TSource>
//    {
//        private IEnumerable<TSource> source;
//        private ProjectionComparer<TSource, object> projectionComparer;

//        public OrderedEnumerable(IEnumerable<TSource> source, ProjectionComparer<TSource, object> projectionComparer)
//        {
//            this.source = source;
//            this.projectionComparer = projectionComparer;
//        }

//        public IOrderedEnumerable<TSource> CreateOrderedEnumerable<TKey>(System.Func<TSource, TKey> keySelector, IComparer<TKey> comparer, bool descending)
//        {
//            throw new System.NotImplementedException();
//        }

//        public IEnumerator<TSource> GetEnumerator()
//        {
//            throw new System.NotImplementedException();
//        }

//        IEnumerator IEnumerable.GetEnumerator()
//        {
//            throw new System.NotImplementedException();
//        }
//    }
//}