using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TasksPresentation.Model;

namespace TasksPresentation.Examples
{
    public class Ex02TasksStarting
    {
        public void Create()
        {
            // Ciekawe:
            // Artykuł: "7 ways to start a Task in .NET C#" (Andras Nemes)
            // https://dotnetcodr.com/2014/01/01/5-ways-to-start-a-task-in-net-c/



            // Create new Task (Method 1)
            Task.Factory.StartNew(() =>
            {
                // Do stuff here!
            });



            // Create new Task (Method 2)
            Task task = new Task(() =>
            {
                // Do stuff here!
            });
            // (...)
            task.Start();



            // ... you can also return something:
            Task<Person> task2 = new Task<Person>(() =>
            {
                // Do stuff here

                var result = new Person();
                // (...)

                return result;
            });
            task2.Start();

            // Dla zainteresowanych:
            // "Task.Factory.StartNew" vs "new Task(…).Start" (Stephen Toub)
            // https://blogs.msdn.microsoft.com/pfxteam/2010/06/13/task-factory-startnew-vs-new-task-start/




            // Create new Task (Method 3 - .NET 4.5 and newer)
            Task task3 = Task.Run(() =>
            {
                // Do stuff here.
            });


            // It's the same as:
            var task4 = Task.Factory.StartNew(() => {
                // Do stuff here!
            },
            CancellationToken.None,
            TaskCreationOptions.DenyChildAttach,
            TaskScheduler.Default);

            // More details:
            // http://www.pzielinski.com/?p=2844
        }

    }
}
