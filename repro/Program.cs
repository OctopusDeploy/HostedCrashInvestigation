using System;
using System.Threading;

namespace repro
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var mutex = new Mutex(true, "ServerTasks-2441_9XSK8QHN7K"))
            {
                Console.WriteLine("Inside");
            }

            Console.WriteLine("Hello World!");
        }
    }
}