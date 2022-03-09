using System;
using System.Collections;
using System.Collections.Generic;
using static System.String;

namespace DesignPatterns.DesignPatternSolution
{
    //* 1.1. ITERATOR
    public class MainProgram
    {
        internal abstract class Iterator : IEnumerator
        {
            object IEnumerator.Current => Current();
            public abstract int Key();
            protected abstract object Current();
            public abstract bool MoveNext();
            public abstract void Reset();
        }

        internal abstract class IteratorAggregate : IEnumerable
        {
            public abstract IEnumerator GetEnumerator();
        }

        internal class AlphabeticalOrderIterator : Iterator
        {
            private readonly WordsCollection _collection;
            private int _position = -1;
            private readonly bool _reverse = false;

            public AlphabeticalOrderIterator(WordsCollection collection, bool reverse = false)
            {
                _collection = collection;
                _reverse = reverse;

                if (reverse)
                {
                    _position = collection.GetItems().Count;
                }
            }

            protected override object Current()
            {
                return _collection.GetItems()[_position];
            }

            public override int Key()
            {
                return _position;
            }

            public override bool MoveNext()
            {
                int updatedPosition = _position + (_reverse ? -1 : 1);

                if (updatedPosition >= 0 && updatedPosition < _collection.GetItems().Count)
                {
                    _position = updatedPosition;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public override void Reset()
            {
                _position = _reverse ? _collection.GetItems().Count - 1 : 0;
            }
        }

        internal class WordsCollection : IteratorAggregate
        {
            readonly List<string> _collection = new();

            private bool _direction = false;

            public void ReverseDirection()
            {
                _direction = !_direction;
            }

            public List<string> GetItems()
            {
                return _collection;
            }

            public void AddItem(string item)
            {
                _collection.Add(item);
            }

            public override IEnumerator GetEnumerator()
            {
                return new AlphabeticalOrderIterator(this, _direction);
            }
        }

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


    //* 1.2. ABSTRACT FACTORY
    public interface IFactory
    {
        DTOAbstract CreateDTOObject();

        DAOAbstract CreateDAOObject();
    }

    class SupervisorFactory : IFactory
    {
        public DTOAbstract CreateDTOObject()
        {
            return new DTOSupervisor();
        }

        public DAOAbstract CreateDAOObject()
        {
            return new DAOSupervisor();
        }
    }

    class StudentFactory : IFactory
    {
        public DTOAbstract CreateDTOObject()
        {
            return new DTOStudent();
        }

        public DAOAbstract CreateDAOObject()
        {
            return new DAOStudent();
        }
    }

    public interface DTOAbstract
    {
        string UsefulFunction();
    }

    class DTOSupervisor : DTOAbstract
    {
        public string UsefulFunction()
        {
            return "The result of the DTOSupervisor.";
        }
    }

    class DTOStudent : DTOAbstract
    {
        public string UsefulFunction()
        {
            return "The result of the product DTOStudent.";
        }
    }

    public interface DAOAbstract
    {
        string UsefulFunction();

        string AnotherUsefulFunction(DTOAbstract collaborator);
    }

    class DAOSupervisor : DAOAbstract
    {
        public string UsefulFunction()
        {
            return "The result of the DAOSupervisor.";
        }

        public string AnotherUsefulFunction(DTOAbstract collaborator)
        {
            var result = collaborator.UsefulFunction();

            return $"The result of the DAOSupervisor collaborating with the ({result})";
        }
    }

    class DAOStudent : DAOAbstract
    {
        public string UsefulFunction()
        {
            return "The result of the DAOStudent.";
        }

        public string AnotherUsefulFunction(DTOAbstract collaborator)
        {
            var result = collaborator.UsefulFunction();

            return $"The result of the DAOStudent collaborating with the ({result})";
        }
    }

    class IFactoryProgram
    {
        private static void SupportMethod(IFactory factory)
        {
            var daoObject = factory.CreateDAOObject();
            var dtoObject = factory.CreateDTOObject();

            Console.WriteLine(daoObject.UsefulFunction());
            Console.WriteLine(daoObject.AnotherUsefulFunction(dtoObject));
        }

        public static void Run()
        {
            Console.WriteLine("Client: Testing client code with the StudentFactory type...");
            SupportMethod(new StudentFactory());
            Console.WriteLine();

            Console.WriteLine("Client: Testing the same client code with the SupervisorFactory type...");
            SupportMethod(new SupervisorFactory());
        }
    }

    //* 1.3. STRATEGY
    public abstract class Monster
    {
        protected internal string Name { protected init; get; }
        protected int Strength { set; get; }
        protected int Defence { set; get; }
        protected int Agile { set; get; }

        protected Monster()
        {
        }

        protected Monster(string name, int strength, int defence, int agile)
        {
            Name = name;
            Strength = strength;
            Defence = defence;
            Agile = agile;
        }

        public abstract void Attack(Monster monster, int strength);

        public abstract void Avoid(Monster monster);

        public abstract void Defense(Monster monster);
    }

    public class Gargoyle : Monster
    {
        public Gargoyle(string name, int strength, int defence, int agile)
        {
            Name = name;
            Strength = strength;
            Defence = defence;
            Agile = agile;
        }

        public override void Attack(Monster monster, int strength)
        {
            Console.WriteLine(Name + " attacks " + monster.Name + " by: " + strength);
        }

        public override void Avoid(Monster monster)
        {
            Console.WriteLine(Name + " avoids " + monster.Name + " attack");
        }

        public override void Defense(Monster monster)
        {
            Console.WriteLine(Name + " defenses " + monster.Name + " attack ");
        }

        public void SplashWater(Monster monster)
        {
            Console.WriteLine(Name + " splashes water to " + monster.Name);
        }
    }

    public class Goldfinch : Monster
    {
        public Goldfinch(string name, int strength, int defence, int agile)
        {
            Name = name;
            Strength = strength;
            Defence = defence;
            Agile = agile;
        }

        public override void Attack(Monster monster, int strength)
        {
            Console.WriteLine(Name + " attacks " + monster.Name + " by: " + strength);
        }

        public override void Avoid(Monster monster)
        {
            Console.WriteLine(Name + " avoids " + monster.Name + " attack");
        }

        public override void Defense(Monster monster)
        {
            Console.WriteLine(Name + " defenses " + monster.Name + " attack ");
        }

        public void Hunt(Monster monster)
        {
            Console.WriteLine(Name + " hunts for " + monster.Name);
        }
    }

    public class Swara : Monster
    {
        public Swara(string name, int strength, int defence, int agile)
        {
            Name = name;
            Strength = strength;
            Defence = defence;
            Agile = agile;
        }

        public override void Attack(Monster monster, int strength)
        {
            Console.WriteLine(Name + " attacks " + monster.Name + " by: " + strength);
        }

        public override void Avoid(Monster monster)
        {
            Console.WriteLine(Name + " avoids " + monster.Name + " attack");
        }

        public override void Defense(Monster monster)
        {
            Console.WriteLine(Name + " defenses " + monster.Name + " attack ");
        }

        public void SpitAcid(Monster monster, int strength)
        {
            Console.WriteLine(Name + " spits acid on " + monster.Name + " by: " + strength);
        }
    }

    public class StrategyProgram
    {
        public static void Run()
        {
            Console.WriteLine("------- Strategy-------");
            Monster gargoyle = new Gargoyle("Gargoyle", 12, 15, 6);
            Monster goldfinch = new Goldfinch("Goldfinch", 10, 9, 9);
            Monster swara = new Swara("Swara", 7, 7, 15);

            gargoyle.Attack(swara, 5);
            swara.Defense(gargoyle);
            goldfinch.Avoid(gargoyle);
        }
    }

    // 2. SORTED LIST
    public interface ISortStrategy
    {
        void Sort(string[] list);
    }

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

    public class QuickSort : ISortStrategy
    {
        private string[] _names;
        private int _length;

        private void _QuickSort(int lowerIndex, int higherIndex)
        {
            var i = lowerIndex;
            var j = higherIndex;
            var pivot = _names[lowerIndex + (higherIndex - lowerIndex) / 2];

            while (i <= j)
            {
                while (CompareOrdinal(pivot, _names[i]) < 0)
                {
                    i++;
                }

                while (CompareOrdinal(pivot, _names[i]) > 0)
                {
                    j--;
                }

                if (i > j) continue;

                ExchangeNames(i, j);
                i++;
                j--;
            }

            if (lowerIndex < j)
            {
                _QuickSort(lowerIndex, j);
            }

            if (i < higherIndex)
            {
                _QuickSort(i, higherIndex);
            }
        }

        private void ExchangeNames(int i, int j)
        {
            (_names[i], _names[j]) = (_names[j], _names[i]);
        }

        public void Sort(string[] array)
        {
            if (array == null || array.Length == 0)
            {
                return;
            }

            _names = array;
            _length = array.Length;
            _QuickSort(0, _length - 1);
        }
    }

    public class ShellSort : ISortStrategy
    {
        private static void Sort(string[] arr, int arraySize)
        {
            var inc = 3;
            while (inc > 0)
            {
                int i;
                for (i = 0; i < arraySize; i++)
                {
                    var j = i;
                    int temp = arr[0][i];
                    while ((j >= inc) && (arr[0][j - inc] > temp))
                    {
                        arr[j] = arr[j - inc];
                        j -= inc;
                    }

                    arr[j] = temp.ToString();
                }

                if (inc / 2 != 0)
                    inc /= 2;
                else if (inc == 1)
                    inc = 0;
                else
                    inc = 1;
            }
        }

        public void Sort(string[] list)
        {
            Sort(list, list.Length);
        }
    }

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

        public static void Run()
        {
            var sortedListProgram = new SortedListProgram();
            sortedListProgram.RunMergeSort();
            sortedListProgram.RunQuickSort();
            sortedListProgram.RunShellSort();
        }
    }
    

    //* 3. OBSERVER
    public interface IObserver
    {
        void Update(List<int> ints);
    }

    public interface IObservable
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();
    }

    public class Notifier : IObservable
    {
        private List<IObserver> _observers = new();
        private List<int> _integers = new();

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(_integers);
            }
        }

        public void AddInt(int i)
        {
            Notify();
            _integers.Add(i);
            Notify();
        }

        public void RemoveInt(int i)
        {
            Notify();
            _integers.Remove(i);
            Notify();
        }
    }

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

    public class ObserverProgram
    {
        public void Run()
        {
            Console.WriteLine("------- Observer-------");
            var mainNotifier = new Notifier();
            var observer1 = new Waiter();

            mainNotifier.Attach(observer1);

            mainNotifier.AddInt(3);
            mainNotifier.AddInt(5);
            mainNotifier.RemoveInt(3);
        }
    }
}