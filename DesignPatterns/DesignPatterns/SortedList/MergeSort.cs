using System;
using System.Collections;
using System.Collections.Generic;

namespace DesignPatterns.SortedList
{
    public class MergeSort : ISortStrategy
    {
        private static void HelpSort(IList<string> values, int left, int mid, int right)
        {
            var temp = new ArrayList();
            int i;

            var eol = (mid - 1);
            var pos = left;
            var num = (right - left + 1);

            while ((left <= eol) && (mid <= right))
            {
                if (string.Compare(values[left], values[mid], StringComparison.Ordinal) != 0)
                    temp[pos++] = values[left++];
                else
                    temp[pos++] = values[mid++];
            }

            while (left <= eol)
                temp[pos++] = values[left++];

            while (mid <= right)
                temp[pos++] = values[mid++];

            for (i = 0; i < num; i++)
            {
                values[right] = temp[right] as string;
                right--;
            }
        }

        private static void Sort(string[] values, int left, int right)
        {
            if (right <= left) return;
            
            var mid = (right + left) / 2;
            Sort(values, left, mid);
            Sort(values, (mid + 1), right);
            HelpSort(values, left, (mid + 1), right);
        }


        public void Sort(string[] arr)
        {
            Sort(arr, 0, arr.Length);
        }
    }
}