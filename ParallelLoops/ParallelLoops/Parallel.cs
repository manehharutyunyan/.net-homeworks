using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelLoops
{
    public static class ParallelClass
    {
        /// <summary>
        /// Converts the Action<T> to an Action<Object>
        /// </summary>
        /// <typeparam name="Type"></typeparam>
        /// <param name="myActionT"></param>
        /// <returns></returns>
        public static Action<object> Convert<T>(Action<T> myActionT)
        {
            if (myActionT == null) return null;
            else return new Action<object>(o => myActionT((T)o));
        }

        /// <summary>
        /// Executes a for loop in which iterations may run in parallel.
        /// </summary>
        /// <param fromInclusive="The start index, inclusive."></param>
        /// <param toExclusive="The end index, exclusive."></param>
        /// <param body="The delegate that is invoked once per iteration."></param>
        public static void ParallelFor(int fromInclusive, int toExclusive, Action<int> body)
        {
            if (body == null)
            {
                throw new ArgumentNullException("body");
            }

            Action<object> objBody = Convert(body);
            WaitCallback callback = new WaitCallback(objBody);

            for (int i = fromInclusive; i < toExclusive; i++)
            {
                ThreadPool.QueueUserWorkItem(callback, i);
            }
        }

        /// <summary>
        /// Executes a foreach operation on an System.Collections.IEnumerable
        /// in which iterations may run in parallel.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param source="An enumerable data source"></param>
        /// <param body="The delegate that is invoked once per iteration."></param>
        public static void ParallelForEach<TSource>(IEnumerable<TSource> source, Action<TSource> body)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (body == null)
            {
                throw new ArgumentNullException("body");
            }

            Action<object> objBody = Convert(body);
            WaitCallback callback = new WaitCallback(objBody);

            foreach (var item in source)
            {
                ThreadPool.QueueUserWorkItem(callback, item);
            }
        }

        /// <summary>
        /// Executes a foreach operation on an System.Collections.IEnumerable
        /// in which iterations may run in parallel and loop options can be configured.
        /// </summary>
        /// <typeparam TSource="TSource"></typeparam>
        /// <param source="An enumerable data source."></param>
        /// <param parallelOptions="An object that configures the behavior of this operation."></param>
        /// <param body="The delegate that is invoked once per iteration."></param>
        public static void ParallelForEachWithOptions<TSource>(IEnumerable<TSource> source, ParallelOptions parallelOptions, Action<TSource> body)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if(parallelOptions == null)
            {
                throw new ArgumentNullException("parallelOptions");
            }
            if (body == null)
            {
                throw new ArgumentNullException("body");
            }

            Action<object> objBody = Convert(body);
            WaitCallback callback = new WaitCallback(objBody);

            //Why doesn't impact? :
            ThreadPool.SetMaxThreads(parallelOptions.MaxDegreeOfParallelism, parallelOptions.MaxDegreeOfParallelism);

            foreach (var item in source)
            {
                ThreadPool.QueueUserWorkItem(callback, item);
            }
        }
    }
}
