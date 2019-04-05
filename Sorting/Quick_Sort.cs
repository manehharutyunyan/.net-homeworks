using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Quick_Sort
    {
        private static int Partition(int[] a, int p, int q)
        {
            int i = p - 1, j = q + 1;
            int x = a[p];
            while (true)
            {
                do
                {
                    ++i;
                } while (a[i] < x);

                do
                {
                    --j;
                } while (a[j] > x);
                if (i < j)
                {
                    int c = a[i];
                    a[i] = a[j];
                    a[j] = c;

                    //for (int m = 0; m < a.Length; m++)
                    //{
                    //    Console.Write(a[m] + " ");

                    //}
                    //Console.WriteLine();
                    //Console.WriteLine("i:" + i);
                    //Console.WriteLine("j:" + j);
                    //Console.WriteLine();
                }

                else
                    return j;
            }
        }

        public static void QuickSort(int[] a, int p, int q)
        {
            if (p < q)
            {
                int r = Partition(a, p, q);
                QuickSort(a, p, r);
                QuickSort(a, r + 1, q);
            }
        }
    }
}
