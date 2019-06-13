using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathServer
{
    // Common interface for TCP and UDP server classes
    interface INetworkService
    {
        void ProcessResult();
    }
}
