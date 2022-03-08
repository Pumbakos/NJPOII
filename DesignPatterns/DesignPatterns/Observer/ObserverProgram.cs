namespace DesignPatterns.Observer
{
    public class ObserverProgram
    {
        public void Run()
        {
            var mainNotifier = new Notifier();
            var observer1 = new Waiter();
            
            mainNotifier.Attach(observer1);
            
            mainNotifier.AddInt(3);
            mainNotifier.AddInt(5);
            mainNotifier.RemoveInt(3);
        }
    }
}