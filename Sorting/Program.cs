using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Program
    {
        public static void Print(int[] arr)
        {
            for (int i = 0; i < arr.Length;  i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        public static int[] NewArr(int[] arr)
        {
            int[] newArr = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                newArr[i] = arr[i];
            }
            return newArr;
        }

        public static Stopwatch Min(Stopwatch[] a)
        {
            Stopwatch min = a[0];
            for (int i = 1; i < a.Length; ++i)
            {
                if (a[i].Elapsed < min.Elapsed)
                        min = a[i];
            }
            return min;
        }

        public static int MinTime(int[] arr)
        {
            int min = 0;
            int[] newArr = new int[arr.Length];
            newArr = NewArr(arr);
            Stopwatch[] timearr = new Stopwatch[5];
            Stopwatch stopwatch1 = new Stopwatch();
            Stopwatch stopwatch2 = new Stopwatch();
            Stopwatch stopwatch3 = new Stopwatch();
            Stopwatch stopwatch4 = new Stopwatch();
            Stopwatch stopwatch5 = new Stopwatch();

            stopwatch1.Start();
            Insertion_Sort.InsertionSort(newArr);
            stopwatch1.Stop();
            timearr[0] = stopwatch1;
            newArr = NewArr(arr);


            stopwatch2.Start();
            Bubble_sort.BubbleSort(newArr);
            stopwatch2.Stop();
            timearr[1] = stopwatch2;
            newArr = NewArr(arr);


            stopwatch3.Start();
            Merge_Sort.MergeSort(newArr, 0, newArr.Length - 1);
            stopwatch3.Stop();
            timearr[2] = stopwatch3;
            newArr = NewArr(arr);


            stopwatch4.Start();
            Heap_Sort.heapSort(arr);
            stopwatch4.Stop();
            timearr[3] = stopwatch4;
            newArr = NewArr(arr);


            stopwatch5.Start();
            Quick_Sort.QuickSort(newArr, 0, newArr.Length - 1);
            stopwatch5.Stop();
            timearr[4] = stopwatch5;
            newArr = NewArr(arr);


            Stopwatch minStopWatch = Min(timearr);
            if (minStopWatch.Elapsed == stopwatch1.Elapsed)
                min = 1;
            else if (minStopWatch.Elapsed == stopwatch2.Elapsed)
                min = 2;
            else if (minStopWatch.Elapsed == stopwatch3.Elapsed)
                min = 3;
            else if (minStopWatch.Elapsed == stopwatch4.Elapsed)
                min = 4;
            else
                min = 5;

            return min;
        }

        public static void CallInsertionSort(int[] arr)
        {
            int[] newArr = NewArr(arr);
            Console.WriteLine("Insertion sort");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            long memory = GC.GetTotalMemory(false);
            {
                Insertion_Sort.InsertionSort(newArr);
            }
            stopwatch.Stop();
            Print(newArr);
            Console.WriteLine("Running time: {0}", stopwatch.Elapsed);
            Console.WriteLine("Memory usage: {0}", memory);
            Console.WriteLine();
        }

        public static void CallBubbleSort(int[] arr)
        {
            int[] newArr = NewArr(arr);
            Console.WriteLine("Bubble sort");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            long memory = GC.GetTotalMemory(false);
            {
                Bubble_sort.BubbleSort(newArr);
            }
            stopwatch.Stop();
            Print(newArr);
            Console.WriteLine("Running time: {0}", stopwatch.Elapsed);
            Console.WriteLine("Memory usage: {0}", memory);
            Console.WriteLine();
        }

        public static void CallMergeSort(int[] arr)
        {
            int[] newArr = NewArr(arr);
            Console.WriteLine("Merge sort");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            long memory = GC.GetTotalMemory(false);
            {
                Merge_Sort.MergeSort(newArr, 0, newArr.Length - 1);
            }
            stopwatch.Stop();
            Print(newArr);
            Console.WriteLine("Running time: {0}", stopwatch.Elapsed);
            Console.WriteLine("Memory usage: {0}", memory);
            Console.WriteLine();
        }

        public static void CallHeapSort(int[] arr)
        {
            int[] newArr = NewArr(arr);
            Console.WriteLine("Heap sort");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            long memory = GC.GetTotalMemory(false);
            {
                Heap_Sort.heapSort(arr);
            }
            stopwatch.Stop();
            Print(newArr);
            Console.WriteLine("Running time: {0}", stopwatch.Elapsed);
            Console.WriteLine("Memory usage: {0}", memory);
            Console.WriteLine();
        }

        public static void CallQuickSort(int[] arr)
        {
            int[] newArr = NewArr(arr);
            Console.WriteLine("Quick sort");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            long memory = GC.GetTotalMemory(false);
            {
                Quick_Sort.QuickSort(newArr, 0, newArr.Length - 1);
            }
            stopwatch.Stop();
            Print(newArr);
            Console.WriteLine("Running time: {0}", stopwatch.Elapsed);
            Console.WriteLine("Memory usage: {0}", memory);
            Console.WriteLine();
        }

        public static void Insertion()
        {
            Console.WriteLine("===============================================");
            Console.WriteLine("Please enter the size of an array that you want to sort: ");

            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please enter the list of numbers that you want to sort: ");

            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }


            Console.WriteLine("Select which algorithm you want to perform:");
            Console.WriteLine("1. Insertion sort\n2. Bubble sort\n3. Quick sort");
            Console.WriteLine("4. Heap sort\n5. Merge sort\n6. All");

            String str = Console.ReadLine();


            int minTime = MinTime(arr);
            if (str.Length > 1 && Convert.ToChar(str[1]).Equals('-'))
            {
                int start = (int)Char.GetNumericValue(str[0]);
                int end = (int)Char.GetNumericValue(str[2]);
                for (int j = start; j <= end; j++)
                {
                    switch (j)
                    {
                        case 1:
                            if(minTime == 1)
                                Console.ForegroundColor = ConsoleColor.Green;
                            CallInsertionSort(arr);
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case 2:
                            if (minTime == 2)
                                Console.ForegroundColor = ConsoleColor.Green;
                            CallBubbleSort(arr);
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case 3:
                            if (minTime == 3)
                                Console.ForegroundColor = ConsoleColor.Green;
                            CallQuickSort(arr);
                            Console.ForegroundColor = ConsoleColor.White;

                            break;
                        case 4:
                            if (minTime == 4)
                                Console.ForegroundColor = ConsoleColor.Green;
                            Heap_Sort.heapSort(arr);
                            Heap_Sort.heapSort(arr);
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case 5:
                            if (minTime == 5)
                                Console.ForegroundColor = ConsoleColor.Green;
                            CallMergeSort(arr);
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case 6:
                            Console.WriteLine("All");
                            if (minTime == 1)
                                Console.ForegroundColor = ConsoleColor.Green;
                            CallInsertionSort(arr);
                            Console.ForegroundColor = ConsoleColor.White;

                            if (minTime == 2)
                                Console.ForegroundColor = ConsoleColor.Green;
                            CallBubbleSort(arr);
                            Console.ForegroundColor = ConsoleColor.White;

                            if (minTime == 3)
                                Console.ForegroundColor = ConsoleColor.Green;
                            CallMergeSort(arr);
                            Console.ForegroundColor = ConsoleColor.White;

                            if (minTime == 4)
                                Console.ForegroundColor = ConsoleColor.Green;
                            Heap_Sort.heapSort(arr);
                            Console.ForegroundColor = ConsoleColor.White;

                            if (minTime == 5)
                                Console.ForegroundColor = ConsoleColor.Green;
                            CallQuickSort(arr);
                            Console.ForegroundColor = ConsoleColor.White;

                            break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < str.Length; i++)
                {
                    int x = (int)Char.GetNumericValue(str[i]);
                    switch (x)
                    {
                        case 1:
                            if (minTime == 1)
                                Console.ForegroundColor = ConsoleColor.Green;
                            CallInsertionSort(arr);
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case 2:
                            if (minTime == 2)
                                Console.ForegroundColor = ConsoleColor.Green;
                            CallBubbleSort(arr);
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case 3:
                            if (minTime == 3)
                                Console.ForegroundColor = ConsoleColor.Green;
                            CallQuickSort(arr);
                            Console.ForegroundColor = ConsoleColor.White;

                            break;
                        case 4:
                            if (minTime == 4)
                                Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Heap sort");
                            CallHeapSort(arr);
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case 5:
                            if (minTime == 5)
                                Console.ForegroundColor = ConsoleColor.Green;
                            CallMergeSort(arr);
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case 6:
                            Console.WriteLine("All");
                            if (minTime == 1)
                                Console.ForegroundColor = ConsoleColor.Green;
                            CallInsertionSort(arr);
                            Console.ForegroundColor = ConsoleColor.White;

                            if (minTime == 2)
                                Console.ForegroundColor = ConsoleColor.Green;
                            CallBubbleSort(arr);
                            Console.ForegroundColor = ConsoleColor.White;

                            if (minTime == 3)
                                Console.ForegroundColor = ConsoleColor.Green;
                            CallMergeSort(arr);
                            Console.ForegroundColor = ConsoleColor.White;

                            if (minTime == 4)
                                Console.ForegroundColor = ConsoleColor.Green;
                            CallHeapSort(arr);
                            Console.ForegroundColor = ConsoleColor.White;

                            if (minTime == 5)
                                Console.ForegroundColor = ConsoleColor.Green;
                            CallQuickSort(arr);
                            Console.ForegroundColor = ConsoleColor.White;

                            break;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Insertion();
        }

    }
}
