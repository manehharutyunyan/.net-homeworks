using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Insertion_Sort
    {
        public static void InsertionSort(int[] a)
        {
            for (int i = 0; i < a.Length - 1; ++i)
            {
                for (int j = i + 1; j > 0; --j)
                {
                    if (a[j] < a[j - 1])
                    {
                        int tmp = a[j];
                        a[j] = a[j - 1];
                        a[j - 1] = tmp;
                    }
                }
            }
        }
    }
}
