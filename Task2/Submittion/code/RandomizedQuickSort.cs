using System;
using System.Collections.Generic;
using Vector;

namespace Sorter
{
    public class RandomizedQuickSort : ISorter
    {
        public void Sort<T>(T[] sequence, IComparer<T> comparer) where T : IComparable<T>
        {
            if (comparer == null)
                comparer = Comparer<T>.Default;

            QuickSort(sequence, comparer, 0, sequence.Length - 1);
        }
        public void QuickSort<T>(T[] array, IComparer<T> comparer, int begin, int end) where T : IComparable<T>
        {
            if (begin >= end)
            {
                return;
            }
            int pivotIndex = QuickSort_Once(array, begin, end, comparer);  //会得到一个基准值下标
            QuickSort(array, comparer, begin, pivotIndex - 1);  //对基准的左端进行排序  递归
            QuickSort(array, comparer, pivotIndex + 1, end);   //对基准的右端进行排序  递归
        }
        public static int QuickSort_Once<T>(T[] arr, int begin, int end, IComparer<T> comparer)
        {
            T pivot_temp = arr[begin];   //将首元素作为基准
            int i = begin;
            int j = end;
            while (i < j)
            {
                while (comparer.Compare(arr[j], pivot_temp) >= 0 && i < j)  //从右到左，寻找第一个小于基准pivot的元素
                {
                    j--; //指针向前移
                }
                arr[i] = arr[j];
                
                while (comparer.Compare(arr[i], pivot_temp) <= 0 && i < j) //从左到右，寻找首个大于基准pivot的元素
                {
                    i++; //指针向后移
                }
                // Swap(ref arr[j],ref arr[i]);  //执行到此,i已指向从左端起首个大于基准pivot的元素，执行替换
                arr[j] = arr[i];
            }
            arr[i] = pivot_temp;
            return i;
        }
        public static void Swap<T>(ref T t1, ref T t2)
        {
            T tmp = t2;
            t2 = t1;
            t1 = tmp;
        }
    }
}