using System;
using System.Collections.Generic;

namespace Vector
{
    public class MergeSortTopDown : ISorter
    {
        public void Sort<T>(T[] sequence, IComparer<T> comparer) where T : IComparable<T>
        {
            // To be completed as part of assessment
            if (comparer == null)
                comparer = Comparer<T>.Default;

            MSort(sequence, sequence, 0, sequence.Length-1, comparer);
        }
        public void MSort<T>(T[] SR, T[] TR1, int s, int t, IComparer<T> comparer)
        {
            int m;
            T[] TR2 = new T[SR.Length]; 
            if (s == t)
            {
                TR1[s] = SR[s];
            }
            else
            {
                m = (s + t) / 2;
                MSort(SR, TR2, s, m, comparer);
                MSort(SR, TR2, m+1, t, comparer);

                Merge(TR2, TR1, s, m, t, comparer);
            }
        }
        private void Merge<T>(T[] SR, T[] TR, int i, int m, int n, IComparer<T> comparer)
        {
            int j, k, l;
            for (j = m+1, k=i; i <= m && j <= n; k++)
            {
                if (comparer.Compare(SR[i], SR[j]) < 0)
                {
                    TR[k] = SR[i++];
                }
                else
                {
                    TR[k] = SR[j++];
                }
            }
            if (i <= m)
            {
                for (l = 0; l <= m - i; l++)
                {
                    TR[k + l] = SR[i+l];
                }
            }
            if (j <= n)
            {
                //将剩余的SR[j..m]复制到TR
                for (l = 0; l <= n - j; l++)
                {
                    TR[k + l] = SR[j+l];
                }
            }
        }

        // this now swaps source and destination
        private void Swap<T>(ref T t1, ref T t2)
        {
            T tmp = t2;
            t2 = t1;
            t1 = tmp;
        }
    }
}
