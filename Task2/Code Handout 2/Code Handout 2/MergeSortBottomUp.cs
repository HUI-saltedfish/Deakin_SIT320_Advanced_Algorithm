using System;
using System.Collections.Generic;

namespace Vector
{
    public class MergeSortBottomUp : ISorter
    {
        public void Sort<T>(T[] sequence, IComparer<T> comparer) where T : IComparable<T>
        {
            // To be completed as part of assessment
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
