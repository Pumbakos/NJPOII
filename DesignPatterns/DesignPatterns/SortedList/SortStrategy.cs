using System.Collections;
using System.Collections.Generic;

namespace DesignPatterns.SortedList
{
    public interface ISortStrategy
    {
        void Sort(string[] list);
    }
}