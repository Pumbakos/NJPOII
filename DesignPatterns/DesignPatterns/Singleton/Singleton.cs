namespace DesignPatterns.Singleton
{
    public class Singleton
    {
        private static volatile Singleton _instance;
        private static readonly object SyncRoot = new();

        public static Singleton Instance;

        public static Singleton GetInstance()
        {
            if (_instance != null)
            {
                return _instance;
            }

            lock (SyncRoot)
            {
                if (_instance == null)
                {
                    _instance = new Singleton();
                }
            }

            return _instance;
        }

        private Singleton()
        {
        }
    }
}