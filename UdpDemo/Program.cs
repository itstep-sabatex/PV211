// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using UdpDemo;

Console.WriteLine("Hello, World!");
UdpClient udpClient = new UdpClient();
var endPoint = new IPEndPoint(IPAddress.Any,11000);
udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, 11000));
UdpState state = new UdpState() {e = endPoint,u=udpClient};
var r = udpClient.BeginReceive(new AsyncCallback(RecesiveCallback), state);


while (true)
{
    var data = Encoding.UTF8.GetBytes("ABCD");
    //udpClient.Send(data, data.Length, "172.29.13.255", 11000);
    udpClient.BeginSend(data, data.Length, "localhost", 11000, new AsyncCallback(SendCallback), udpClient);
    Thread.Sleep(1000);

}

void SendCallback(IAsyncResult ar)
{
    var a = ar.IsCompleted;
}




//var ipEndpoint = new IPEndPoint(IPAddress.Any, 11000);


void RecesiveCallback(IAsyncResult ar)
{
    String content = String.Empty;
    var a = ar.IsCompleted;
    var handler = ((UdpState) ar.AsyncState).u;
    var endpoint = ((UdpState)ar.AsyncState).e;
    byte[] bytes = handler.EndReceive(ar,ref endpoint);
    Console.WriteLine($"{endpoint.Address} message: {Encoding.ASCII.GetString(bytes) }");
}

//"192.167.1.255" 0xFF   0-255    "192.168.1.0"  "255.255.255.0"  "192.168.1.255"
// "192.168.1.0"  "255.255.0.0"  "192.168.255.255"