using System;

namespace SingletonLazy
{
    public sealed class ClaseEjemplo
    {
        private static object locked = new object();
        private static ClaseEjemplo _instance;

        public static ClaseEjemplo Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (locked)
                    {
                        if (_instance == null)
                        {
                            _instance = new ClaseEjemplo();
                        }
                    }
                }
                return _instance;
            }
        }
    }

    public sealed class ClaseEjemplo2
    {

        private static readonly Lazy<ClaseEjemplo2> lazy =
            new Lazy<ClaseEjemplo2>(() => new ClaseEjemplo2());

        public static ClaseEjemplo2 Instance
        {
            get
            {
                return lazy.Value;
            }
        }
    }
}
