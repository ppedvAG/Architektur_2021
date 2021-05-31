using System;
using System.Threading.Tasks;

namespace HalloSingelton
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Singelton!");

            Parallel.For(0, 100, i => Logger.Instance.Log($"{i} Hallo Logger "));

            Logger.Instance.Log("Nochmal Hallo Logger");
        }
    }

    class Logger
    {
        //public static Logger Instance { get; } = new Logger();
        private static Logger instance = null;
        private static object syncObj = new object();
        public static Logger Instance
        {
            get
            {
                lock (syncObj)
                {
                    if (instance == null)
                        instance = new Logger();
                }

                return instance;
            }
        }

        static int instanceCounter = 0;
        int instanceNumber = 0;
        private Logger()
        {
            instanceCounter++;
            instanceNumber = instanceCounter;
            Log("Logger started");
        }

        public void Log(string msg)
        {
            Console.WriteLine($"[{DateTime.Now}] [{instanceNumber}/{instanceCounter}]   {msg}");
        }
    }
}
