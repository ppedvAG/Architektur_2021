using System;

namespace HalloSingelton
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Singelton!");

            Logger.Instance.Log("Hallo Logger");

            Logger.Instance.Log("Nochmal Hallo Logger");

        }
    }

    class Logger
    {
        private static Logger instance = null;
        public static Logger Instance
        {
            get
            {
                if (instance == null)
                    instance = new Logger();
                return instance;
            }
        }

        static int instanceCounter = 0;
        private Logger()
        {
            instanceCounter++;
            Log("Logger started");
        }

        public void Log(string msg)
        {
            Console.WriteLine($"[{DateTime.Now}] [{instanceCounter}]  {msg}");
        }
    }
}
