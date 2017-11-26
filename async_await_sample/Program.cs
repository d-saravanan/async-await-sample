using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace async_await_sample
{
    using static ConsoleLogger;
    class Program
    {
        static void Main(string[] args)
        {
            Log("0. Starting the program");
            var ae = new AsyncExample();
            Task demoTask = ae.DemoEntryMethod();
            demoTask.Wait();
            Log("7. Main program exiting after you hit the enter key...");
            Console.ReadLine();
        }
    }

    public class AsyncExample
    {
        public async Task<int> DoSomething()
        {
            Log("1. the below method has the await which will return the control to the caller");
            await Task.Run(() => { Thread.Sleep(2000); Log("4. done waiting for 2 seconds"); });
            return (new Random().Next(1, 10000));
        }

        public async Task Demonstrate()
        {
            var task2Await = DoSomething();
            Log("2. got the task now.");
            Log("5. The result of the task is : " + (await task2Await).ToString());
        }
        public async Task DemoEntryMethod()
        {
            var result = Demonstrate();
            Log("3. invoked the demonstrate method from within the demonstrate1 method and got the task");
            await result;
            Log("6. done the demonstration one");
        }
    }

    public static class ConsoleLogger
    {
        public static void Log(string message) => Console.WriteLine(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "\t" + message);
    }
}
