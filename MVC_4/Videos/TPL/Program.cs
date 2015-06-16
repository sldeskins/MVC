using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TPL
{
    class Program
    {
        static void Main ( string[] args )
        {
            var task =  SlowOperationAsync();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }

        
            Console.WriteLine("Slow operation result: {0}", task.Result);
            Console.WriteLine("Main thread complete on {0}", Thread.CurrentThread.ManagedThreadId);

            Console.ReadLine();
        }

        static async Task<int> SlowOperationAsync ()
        {
            Console.WriteLine("Slow operation started on {0}", Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(2000);
            Console.WriteLine("Slow operation complete on {0}", Thread.CurrentThread.ManagedThreadId);
            return 42;
        }
    }
}
