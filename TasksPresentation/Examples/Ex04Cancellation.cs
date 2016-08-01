using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TasksPresentation.Examples
{
    public class Ex04Cancellation
    {
        
        public static void RunCancellableTask1()
        {
            var tokenSource = new CancellationTokenSource();
            var cancelToken = tokenSource.Token;

            var task = Task.Factory.StartNew(() =>
            {
                while(true)
                {
                    Console.WriteLine(string.Format("{0} Hello! :)", DateTime.Now));
                    Thread.Sleep(1000);

                    if(cancelToken.IsCancellationRequested)
                    {
                        break;
                    }
                }
            } , cancelToken);

            cancelToken.Register(() =>
            {
                Console.WriteLine("Task cancelled!");
            });

            // (...)

            Thread.Sleep(3000);
            tokenSource.Cancel();

            task.Wait(); // Status: RanToCompletion
        }


        public static void RunCancellableTask2()
        {
            var tokenSource = new CancellationTokenSource();
            var cancelToken = tokenSource.Token;

            var task = Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Console.WriteLine(string.Format("{0} Hello! :)", DateTime.Now));
                    Thread.Sleep(1000);

                    cancelToken.ThrowIfCancellationRequested();
                }
            }, cancelToken);

            cancelToken.Register(() =>
            {
                Console.WriteLine("Task cancelled!");
            });

            // (...)

            Thread.Sleep(3000);
            tokenSource.Cancel();

            try
            {
                task.Wait(); // Status: Canceled
            }
            catch(AggregateException e)
            {
                foreach (var v in e.InnerExceptions)
                    Console.WriteLine(e.Message + " " + v.Message);
            }
        }

        // Ciekawe z MSDN:
        // How to: Cancel a Task and Its Children
        // https://msdn.microsoft.com/en-us/library/dd537607(v=vs.110).aspx
    }
}
