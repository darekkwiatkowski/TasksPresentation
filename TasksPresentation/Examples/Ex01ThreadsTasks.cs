using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TasksPresentation.Examples
{
    class Ex01ThreadsTasks
    {
        public void Create()
        {
            //
            // Thread is a lower-level concept: if you're directly starting a thread, 
            // you know it will be a separate thread, rather than executing on the thread pool etc.
            //

            // Create new Thread.
            var thread = new Thread(start =>
            {
                // Do stuff here!
            });
            thread.Start();

            // --------------------------------------------------------------------------------

            //
            // A "Task" is a piece of work that will execute, and complete at some point in the future.
            //

            // Create new Task
            var task = Task.Factory.StartNew(() =>
            {
                // Do stuff here!
            });

            // Execute it when the task is completed.
            var continuationTask = task.ContinueWith(t => 
            {
                // Do some more stuff here!
            });


            // You can also create parent-child relationships.
            var parent = Task.Factory.StartNew(() =>
            {
                // (...)

                Task.Factory.StartNew(() =>
                {
                    // I'm a child task.
                },
                TaskCreationOptions.AttachedToParent);
            });
            
        }

        
    }
}
