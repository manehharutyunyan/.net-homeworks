using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MathClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose the protocol \n1. TCP \n2.UDP");
            int protocol = Int32.Parse(Console.ReadLine());
            Console.WriteLine(protocol);
            Console.WriteLine("Write your expression with operator:first_value:second_value form");
            string message = Console.ReadLine();
            if(protocol == 1)
            {
                TCP tsp = new TCP();
                tsp.SendMessage(message);
            }
            if (protocol == 2)
            {
                UDP udp = new UDP();
                udp.SendMessage(message);
            }
            Console.ReadKey();
        }
    }
}
