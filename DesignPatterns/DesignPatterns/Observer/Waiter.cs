using System;
using System.Collections.Generic;

namespace DesignPatterns.Observer
{
    public class Waiter : IObserver
    {
        public void Update(List<int> ints)
        {
            Console.WriteLine("Collection has changed!");
            Console.Write("Collection: ");
            foreach (var item in ints)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }
    }
}