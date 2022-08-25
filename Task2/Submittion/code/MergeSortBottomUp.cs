using System;
using System.Collections.Generic;

namespace Vector
{
    public class MergeSortBottomUp : ISorter
    {
        public void Sort<T>(T[] sequence, IComparer<T> comparer) where T : IComparable<T>
        {
            // To be completed as part of assessment
            if (comparer == null)
                comparer = Comparer<T>.Default;

            T[] TR = new T[sequence.Length];
            int k = 1;
            while (k < sequence.Length)
            {
                MergePass(sequence, TR, k, sequence.Length - 1, comparer);
                k = 2 * k;
                MergePass(TR, sequence, k, sequence.Length - 1, comparer);
                k = 2 * k;
            }
        }
        public void MergePass<T>(T[] SR, T[] TR, int s, int n, IComparer<T> comparer)
        {
            int i = 0, j;
            //两两归并
            while (i <= n - 2 * s + 1)
            {
                Merge(SR, TR, i, i + s - 1, i + 2 * s - 1, comparer);
                i = i + 2 * s;
            }
            //归并最后两个子序列
            if (i < n - s + 1)
            {
                Merge(SR, TR, i, i + s - 1, n, comparer);
            }
            //若最后只剩单个子序列
            else
            {
                for (j = i; j <= n; j++)
                {
                    TR[j] = SR[j];
                }
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
