using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
 
namespace TaskParallelLibraryExample {
     
    public class TaskParallelLibraryExample {
     
        public TaskParallelLibraryExample(){
            Console.WriteLine("\nTaskParallelLibraryExample");
                 
            // Example 1        
            var task1 = new Task(() => {
                Console.WriteLine("Task 1 begins");
                Thread.Sleep(1000);
                Console.WriteLine("Task 1 ends");               
            });
            task1.Start();
             
            DisplayPressAnyKey();
             
            Console.WriteLine("------");
             
            // Example 2
             
            var task2 = new Task(() => {
                DoTask(2, 1000);    
            });
            task2.Start();
             
            DisplayPressAnyKey();
             
            Console.WriteLine("------");
             
            // Example 3
             
            var task3 = new Task(() => {
                DoTask(3, 1000);    
            });
            task3.Start();
 
            var task4 = new Task(() => {
                DoTask(4, 1000);    
            });
            task4.Start();
 
            var task5 = new Task(() => {
                DoTask(5, 1000);    
            });
            task5.Start();
 
            DisplayPressAnyKey();
             
            Console.WriteLine("------");
 
            // Example 4
             
            var task6 = Task.Factory.StartNew(() => {
                DoTask(6, 1000);    
            });
 
            var task7 = Task.Factory.StartNew(() => {
                DoTask(7, 1000);    
            });
 
            var task8 = Task.Factory.StartNew(() => {
                DoTask(8, 1000);    
            });
 
            DisplayPressAnyKey();
             
            Console.WriteLine("------");
         
            // Example 5
             
            var tasks9_10_11 = Task.Factory.StartNew(() => DoTask(9, 1000))
                        .ContinueWith((prevTask) => DoTask(10,1000))
                        .ContinueWith((prevTask) => DoTask(11,1000));
 
            DisplayPressAnyKey();
             
            Console.WriteLine("------");
             
            // Example 6
             
            var task12 = Task.Factory.StartNew(() => DoTask(12, 1000));
            var task13 = Task.Factory.StartNew(() => DoTask(13, 1000));
            var task14 = Task.Factory.StartNew(() => DoTask(14, 1000));
 
            var taskList = new List<Task>{ task12, task13, task14 };
            Task.WaitAll(taskList.ToArray());
             
            DisplayPressAnyKey();
             
            Console.WriteLine("------");
     
            // Example 7
             
            var task15 = Task.Factory.StartNew(() => DoTask(15, 1000));
            var task16 = Task.Factory.StartNew(() => DoTask(16, 1000));
            var task17 = Task.Factory.StartNew(() => DoTask(17, 1000));
 
            for (var i = 0; i < 10; ++i){
                Console.WriteLine("Inside task begins");
                Thread.Sleep(300);
                Console.WriteLine("Inside task ends");
            }
             
            DisplayPressAnyKey();
             
            Console.WriteLine("------");
             
            // Example 8
             
            var task18 = Task.Factory.StartNew(() => DoTask(18, 1000));
            var task19 = Task.Factory.StartNew(() => DoTask(19, 1000));
            var task20 = Task.Factory.StartNew(() => DoTask(20, 1000));
 
            taskList = new List<Task>{ task18, task19, task20 };
            Task.WaitAll(taskList.ToArray());
 
            for (var i = 0; i < 10; ++i){
                Console.WriteLine("Inside task again begins");
                Thread.Sleep(300);
                Console.WriteLine("Inside task again ends");
            }
             
            DisplayPressAnyKey();
             
            Console.WriteLine("------");
             
            // Example 9
            var listNames = new List<string> { "Alex", "Diego", "Vanina", "Ariel", "Juan", "David", "Candece", "Pablo", "Agustin"};
            Parallel.ForEach(listNames, name => Console.WriteLine(name));
             
            DisplayPressAnyKey();
             
            Console.WriteLine("------");
 
            // Example 10
            Parallel.For(0, 100, (number) => Console.Write(number + "->"));
                         
            Console.WriteLine("\n------");
             
            // Example 11
            var cancelSource = new CancellationTokenSource();
            try{
                var continueTasks = Task.Factory.StartNew(() => DoTask(21, 1000))
                                    .ContinueWith((prevTask) => DoTask(22, 1000))
                                    .ContinueWith((prevTask) => DoAnotherTask(23, 1000, cancelSource.Token))
                                    .ContinueWith((prevTask) => DoTask(24, 1000));       
                cancelSource.Cancel();      
            } catch(Exception ex){
                Console.WriteLine("Exception: " + ex.GetType());
            }
             
            Console.WriteLine("\n------");
                 
        }
         
        private void DisplayPressAnyKey(){
            Console.WriteLine("Press any key to quit");
            Console.ReadKey();          
        }
         
        private void DoTask(int id, int sleepTimeInMilliSeconds){
            Console.WriteLine("Task {0} begins", id);
            Thread.Sleep(1000);
            Console.WriteLine("Task {0} ends", id);             
        }
         
        private void DoAnotherTask(int id, int sleepTimeInMilliSeconds, CancellationToken token){
            if (token.IsCancellationRequested) {
                Console.WriteLine("Cancellation request");
                token.ThrowIfCancellationRequested();
            }
             
            Console.WriteLine("Another Task {0} begins", id);
            Thread.Sleep(1000);
            Console.WriteLine("Another Task {0} ends", id);             
        }
         
    }
     
}