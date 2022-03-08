using System;

namespace DesignPatterns.Iterator
{
    public class IteratorProgram
    {
        public void Run()
        {
            var collection = new WordsCollection();
            collection.AddItem("First");
            collection.AddItem("Second");
            collection.AddItem("Third");

            Console.WriteLine("1. Iterator:");

            Console.WriteLine("\tStraight traversal:");

            foreach (var element in collection)
            {
                Console.WriteLine("\t \t" + element);
            }

            Console.WriteLine("\n \tReverse traversal:");

            collection.ReverseDirection();

            foreach (var element in collection)
            {
                Console.WriteLine("\t \t" + element);
            }
        }
    }
}