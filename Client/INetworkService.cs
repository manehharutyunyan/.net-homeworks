using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClient
{
    // Common interface for TCP and UDP client classes
    interface INetworkService
    {
        void SendMessage(string message);
    }
}
