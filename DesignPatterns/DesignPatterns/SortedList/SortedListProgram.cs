using System;

namespace DesignPatterns.SortedList
{
    public class SortedListProgram
    {
        public void RunMergeSort()
        {
            var sortedList = new SortedList();
            sortedList.Add("Samual");
            sortedList.Add("Jimmy");
            sortedList.Add("Sandra");
            sortedList.Add("Vivek");
            sortedList.Add("Anna");
            sortedList.Add("Danny");
            sortedList.Add("Nathan");
            sortedList.Print();
            
            Console.WriteLine("Sorting using MergeSort ...");
            sortedList.SetSortStrategy(new MergeSort());
            
            Console.WriteLine("Sorted list:");
            sortedList.Sort();
            sortedList.Print();
        }
        
        public void RunQuickSort()
        {
            var sortedList = new SortedList();
            sortedList.Add("Samual");
            sortedList.Add("Jimmy");
            sortedList.Add("Sandra");
            sortedList.Add("Vivek");
            sortedList.Add("Anna");
            sortedList.Add("Danny");
            sortedList.Add("Nathan");
            sortedList.Print();
            
            Console.WriteLine("Sorting using QuickSort ...");
            sortedList.SetSortStrategy(new QuickSort());
            
            Console.WriteLine("Sorted list:");
            sortedList.Sort();
            sortedList.Print();
        }
        
        public void RunShellSort()
        {
            var sortedList = new SortedList();
            sortedList.Add("Samual");
            sortedList.Add("Jimmy");
            sortedList.Add("Sandra");
            sortedList.Add("Vivek");
            sortedList.Add("Anna");
            sortedList.Add("Danny");
            sortedList.Add("Nathan");
            sortedList.Print();
            
            Console.WriteLine("Sorting using ShellSort ...");
            sortedList.SetSortStrategy(new ShellSort());
            
            Console.WriteLine("Sorted list:");
            sortedList.Sort();
            sortedList.Print();
        }
    }
}