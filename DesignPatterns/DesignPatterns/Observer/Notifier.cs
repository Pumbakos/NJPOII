using System.Collections.Generic;

namespace DesignPatterns.Observer
{
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
}