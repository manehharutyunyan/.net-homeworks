using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Merge_Sort
    {
        private static void Merge(int[] a, int p, int r, int q)
        {
            int curr = p;
            int n1 = r - p + 1;
            int n2 = q - r;
            int[] a1 = new int[n1];
            int[] a2 = new int[n2];
            int i = 0, j = 0;

            for (i = 0; i < n1; i++)
            {
                a1[i] = a[p + i];
            }
            for (i = 0; i < n2; i++)
            {
                a2[i] = a[r + i + 1];
            }

            i = 0; j = 0;
            while (i < n1 && j < n2)
            {
                if (a1[i] < a2[j])
                {
                    a[curr] = a1[i];
                    ++i;
                    ++curr;
                }
                else
                {
                    a[curr] = a2[j];
                    ++j;
                    ++curr;
                }
            }
            while (i < n1)
            {
                a[curr] = a1[i];
                ++i;
                ++curr;
            }
            while (j < n2)
            {
                a[curr] = a2[j];
                ++j;
                ++curr;
            }
        }

        public static void MergeSort(int[] a, int p, int q)
        {
            if (p < q)
            {
                int r = (q + p) / 2;
                MergeSort(a, p, r);
                MergeSort(a, r + 1, q);
                Merge(a, p, r, q);
            }
        }
    }
}
