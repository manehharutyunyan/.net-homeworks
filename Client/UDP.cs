using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MathClient
{
    public class UDP : INetworkService
    {
        public void SendMessage(string message)
        {
            Int32 port = 13000;
            string localAddr = "127.0.0.1";
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            IPAddress broadcast = IPAddress.Parse(localAddr);

            byte[] sendbuf = Encoding.ASCII.GetBytes(message);
            IPEndPoint ep = new IPEndPoint(broadcast, port);

            sock.SendTo(sendbuf, ep);

            byte[] recvbuf = new byte[256];
            Int32 bytes = sock.Receive(recvbuf);

            // String to store the response ASCII representation.
            String responseData = String.Empty;
            responseData = System.Text.Encoding.ASCII.GetString(recvbuf, 0, bytes);
            Console.WriteLine("Received: {0}", responseData);

            Console.WriteLine("Message sent to the broadcast address");
        }
    }
}
