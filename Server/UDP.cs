using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MathServer
{
    public class UDP : INetworkService
    {
        public void ProcessResult()
        {
            int port = 13000;
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");
            UdpClient listener = new UdpClient(port);
            IPEndPoint groupEP = new IPEndPoint(localAddr, port);
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);


            try
            {
                while (true)
                {
                    Console.WriteLine("UDP server is waiting for broadcast... ");
                    byte[] bytes = listener.Receive(ref groupEP);

                    Console.WriteLine($"Received broadcast from {groupEP} :");
                    string data = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                    Console.WriteLine($" {data}");

                    // Process the data sent by the client.
                    MathService mathService = new MathService();
                    double result = mathService.PerformOperation(data);
                    data = result.ToString();

                    bytes = System.Text.Encoding.ASCII.GetBytes(data);

                    sock.SendTo(bytes, groupEP);
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                listener.Close();
            }
        }
    }
}
