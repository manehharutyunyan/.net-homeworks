using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelLoops
{
    class Program
    {
        static void Main(string[] args)
        {
            #region ParallelFor Region
            Stopwatch stopwatch1 = new Stopwatch();
            Stopwatch stopwatch2 = new Stopwatch();

            stopwatch1.Start();
            Parallel.For(0, 5, i =>
            {
                Console.WriteLine("i = {0}, thread = {1}", i,
                Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(10);
            });
            stopwatch1.Stop();
            Console.WriteLine($"stopwatch1 for ParallelFor: {stopwatch1.Elapsed}");

            Console.WriteLine("-----------------------------------------------------------");

            stopwatch2.Start();
            ParallelClass.ParallelFor(0, 5, i =>
            {
                Console.WriteLine("i = {0}, thread = {1}", i,
                Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(10);
            });
            stopwatch2.Stop();
            Console.WriteLine($"stopwatch2 for ParallelFor: {stopwatch2.Elapsed}");
            Console.ReadLine();
            #endregion

            #region ParallelForEach Region

            Stopwatch stopwatch3 = new Stopwatch();
            Stopwatch stopwatch4 = new Stopwatch();

            int[] Numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            stopwatch3.Start();
            Parallel.ForEach(Numbers, number =>
            {
                Console.WriteLine(number);
            });
            stopwatch3.Stop();
            Console.WriteLine($"stopwatch3 for ParallelForEach: {stopwatch3.Elapsed}");

            Console.WriteLine("---------------------------------------------------------");

            stopwatch4.Start();
            ParallelClass.ParallelForEach(Numbers, number =>
            {
                Console.WriteLine(number);
            });
            stopwatch4.Stop();
            Console.WriteLine($"stopwatch4 for ParallelForEach: {stopwatch4.Elapsed}");
            Console.ReadLine();
            #endregion

            #region ParallelForEachWithOptions Region
            //int[] Numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Parallel.ForEach(
                Numbers,
                new ParallelOptions { MaxDegreeOfParallelism = 3 },
                number =>
                {
                    Console.WriteLine("number = {0}, thread = {1}", number, Thread.CurrentThread.ManagedThreadId); ;
                });

            Console.WriteLine("-----------------------------------------------------");

            ParallelClass.ParallelForEachWithOptions(
                Numbers,
                new ParallelOptions { MaxDegreeOfParallelism = 3 },
                number =>
                {
                    Console.WriteLine("number = {0}, thread = {1}", number, Thread.CurrentThread.ManagedThreadId); ;
                });
            #endregion
            Console.ReadLine();
        }
    }
}