using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Threads
{
    class Program
    {

        //class A
        //{

        //    WaitCallback callback = new WaitCallback(PrintMessage);
        //    ThreadPool.QueueUserWorkItem(callback,"Hello");

        //    static void PrintMessage(object obj)
        //    {
        //        Console.WriteLine(obj);
        //    }
        //}
        static void Main(string[] args)
        {

            Action<object> body = SayHello;


            WaitCallback callback = new WaitCallback(body);
            // body(9);

            // System.Threading.WaitCallback(object state);

            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(callback, i);
            }
        }

        private static void SayHello(object arg)
        {
            Thread.CurrentThread.IsBackground = false;
            Console.WriteLine("hello!!!!!!!!!!!!!!" + Thread.CurrentThread.IsBackground);
            int n = (int)arg;
            // Console.WriteLine("say hello" + n);
        }
    }
}
