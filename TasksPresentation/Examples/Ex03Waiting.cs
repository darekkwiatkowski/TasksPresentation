using System;
using System.Threading;
using System.Threading.Tasks;

namespace TasksPresentation.Examples
{
    public class Ex03Waiting
    {
        public static void TestWait()
        {
            var task = new Task(() =>
            {
                Console.WriteLine(string.Format("{0}: Starting...", DateTime.Now));
                Thread.Sleep(2000);
            });
            task.Start();
            task.Wait();
            
            Console.WriteLine(string.Format("{0}: Completed!", DateTime.Now));
        }


        public static void TestWaitAny()
        {
            Task[] tasks = new Task[5];
            for(int i = 0; i < 5; i++)
            {
                int factor = i + 1;
                tasks[i] = Task.Run(() => {
                    Thread.Sleep(factor * 1000);
                    Console.WriteLine(string.Format("{0}: Hello from Task #{1}", DateTime.Now, factor));
                });
            }

            Task.WaitAny(tasks);
            Console.WriteLine(string.Format("{0}: Completed!", DateTime.Now));
        }


        public static void TestWaitAll()
        {
            Task[] tasks = new Task[5];
            for (int i = 0; i < 5; i++)
            {
                int factor = i + 1;
                tasks[i] = Task.Run(() => {
                    Thread.Sleep(factor * 1000);
                    Console.WriteLine(string.Format("{0}: Hello from Task #{1}", DateTime.Now, factor));
                });
            }

            Task.WaitAll(tasks);
            Console.WriteLine(string.Format("{0}: Completed!", DateTime.Now));
        }


        public static async Task<int[]> TestWhenAll()
        {
            Task<int>[] tasks = new Task<int>[5];
            for (int i = 0; i < 5; i++)
            {
                int factor = i + 1;
                tasks[i] = Task<int>.Run(() => {
                    Thread.Sleep(factor * 1000);
                    Console.WriteLine(string.Format("{0}: Hello from Task #{1}", DateTime.Now, factor));
                    return factor;
                });
            }

            // This task is completed when when all of the supplied tasks have completed.
            var finalTask = Task.WhenAll(tasks);

            return await finalTask;
        }
        
    }
}
