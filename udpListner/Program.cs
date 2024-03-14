// See https://aka.ms/new-console-template for more information
using System.Net.Sockets;
using System.Net;
using System.Text;

Console.WriteLine("Hello, World!");
UdpClient udpClient = new UdpClient();
udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, 11001));

while (true)
{
    var ipEndpoint = new IPEndPoint(IPAddress.Any, 11000);
    var recesiveData = udpClient.Receive(ref ipEndpoint);
    Console.WriteLine($"{ipEndpoint.Address}   message:{Encoding.UTF8.GetString(recesiveData)}");

}
