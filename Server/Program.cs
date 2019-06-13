using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace MathServer
{
    class Program
    {
        static void Main(string[] args)
        {
            TCP tcp = new TCP();
            tcp.ProcessResult();

            UDP udp = new UDP();
            udp.ProcessResult();

            //Thread thrUDP = new Thread(udpServer);
            //Thread thrTCP = new Thread(tcpServer);

            //thrTCP.Start();
            //thrUDP.Start();
        }

        //private static void udpServer()
        //{
        //    UDP udp = new UDP();
        //    udp.ProcessResult();
        //}

        //private static void tcpServer()
        //{
        //    UDP udp = new UDP();
        //    udp.ProcessResult();
        //}
    }
}
