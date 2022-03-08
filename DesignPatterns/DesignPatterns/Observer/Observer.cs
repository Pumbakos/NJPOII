using System.Collections.Generic;

namespace DesignPatterns.Observer
{
    public interface IObserver
    {
        void Update(List<int> ints);
    }
}