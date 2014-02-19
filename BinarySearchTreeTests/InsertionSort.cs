using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeTests
{
    public static class InsertionSort
    {
        public static int[] Sort(int[] array)
        {
            int n = array.Length;

            for(int i = 1; i<n;i++)
            {
                for(int j = i; j > 0 && less(array[j],array[j-1]);j--)
                {
                    swap(array, j, j - 1);
                }
            }
            return array;
        }

        public static int[] SortReverse(int[] array)
        {
            int n = array.Length;

            for (int i = 1; i < n; i++)
            {
                for (int j = i; j > 0 && greater(array[j], array[j - 1]); j--)
                {
                    swap(array, j, j - 1);
                }
            }
            return array;
        }

        private static void swap(int[] array, int i, int j)
        {
            var t = array[i];
            array[i] = array[j];
            array[j] = t;
        }

        private static bool less(int p1, int p2)
        {
            return p1 < p2;
        }
        private static bool greater(int p1, int p2)
        {
            return p1 > p2;
        }
    }
}
