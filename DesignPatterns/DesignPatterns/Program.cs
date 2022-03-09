using System;
using DesignPatterns.AbstractFactory;
using DesignPatterns.Iterator;
using DesignPatterns.Observer;
using DesignPatterns.SortedList;
using DesignPatterns.Strategy;

namespace DesignPatterns
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            // 1.1. Iterator 
            Console.WriteLine("------- Iterator -------");
            var iteratorProgram = new IteratorProgram();
            iteratorProgram.Run();
            
            // 1.2.Strategy
            Console.WriteLine("------- Strategy-------");
            Monster gargoyle = new Gargoyle("Gargoyle", 12, 15, 6);
            Monster goldfinch = new Goldfinch("Goldfinch", 10, 9, 9);
            Monster swara = new Swara("Swara", 7, 7, 15);
            
            gargoyle.Attack(swara, 5);
            swara.Defense(gargoyle);
            goldfinch.Avoid(gargoyle);

            // 1.3. Abstract Factory
            Console.WriteLine("------- Abstract Factory-------");
            IFactoryProgram.Run();
            
            // 2. SortedList
            var sortedListProgram = new SortedListProgram();
            sortedListProgram.RunMergeSort();
            sortedListProgram.RunQuickSort();
            sortedListProgram.RunShellSort();
            
            // 3. Observer
            Console.WriteLine("------- Observer-------");
            var observerProgram = new ObserverProgram();
            observerProgram.Run();
        }
    }
}