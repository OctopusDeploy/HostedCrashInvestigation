using System;
using System.Threading;
using System.Threading.Tasks;

namespace repro
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
            var times = 10000000;
            Parallel.For(0, times, (i) => {
                DoMutexThing(i.ToString());
                DoMutexThing((i-1).ToString());
                DoMutexThing(i.ToString());
                DoMutexThing((i+1).ToString());
                DoMutexThing(i.ToString());
                DoMutexThing(i.ToString());
            });
            //Task t1 = Task.Factory.StartNew(() => DoMutexThing("first"));
            //Task t2 = Task.Factory.StartNew(() => DoMutexThing("second"));
            } catch (Exception exception) {
                Console.WriteLine(exception);
            }
            Console.WriteLine("Hello World!");
        }

        private static void DoMutexThing(string threadName)
        {
            using (var mutex = new Mutex(true, threadName))
            {
                //Thread.Sleep(10);
                Console.WriteLine($"Inside thread {threadName}");
            }
        }
    }
}