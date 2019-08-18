using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public static int MyTask()
        {
            for (int i = 0; i <= 20; i++) {
                Console.WriteLine(i.ToString());
                Thread.Sleep(1000);
            }
            return 100;

        }

        public static async Task<int> PrintAsync()
        {
            return await Task.Run(()=>MyTask());
        }

        public static void PrintAsync2()
        {

            var x = PrintAsync().ContinueWith(t=> { });
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!1");

            PrintAsync2();

            Console.WriteLine("Hello World!2");
            Console.ReadKey();
        }
    }
}
