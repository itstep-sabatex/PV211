using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UdpDemo;

public struct UdpState
{
    public UdpClient u;
    public IPEndPoint e;
}
