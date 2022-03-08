using System;

namespace DesignPatterns.SortedList
{
    public class SortedList
    {
        private string[] _list = new string[7];
        private ISortStrategy _strategy;
        private int _iterator = 0;
        
        public void Add(string value)
        {
            _list[_iterator] = value;
            _iterator++;
        }

        public void SetSortStrategy(ISortStrategy sortStrategy)
        {
            _strategy = sortStrategy;
        }

        public void Sort()
        {
            if (_strategy.GetType() == typeof(MergeSort))
            {
                _strategy = new MergeSort();
                try
                {
                    _strategy.Sort(_list);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            
            else if (_strategy.GetType() == typeof(ShellSort))
            {
                _strategy = new ShellSort();
                try
                {
                    _strategy.Sort(_list);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            
            else if (_strategy.GetType() == typeof(QuickSort))
            {
                _strategy = new QuickSort();
                try
                {
                    _strategy.Sort(_list);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public void Print()
        {
            foreach (string item in _list)
            {
                Console.WriteLine(item);
            }
        }
    }
}