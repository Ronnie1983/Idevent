using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        //private static volatile bool exit = false;
        static async Task Main(string[] args)
        {
            //Task.Factory.StartNew(() =>
            //{
            //    while (Console.ReadKey().Key != ConsoleKey.Q) ;
            //    exit = true;
            //});

            //while (!exit)
            //{
                start worker = new start();
                await worker.go();
                Console.ReadKey();
            //}
            
        }
    }
}
