// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Net.Sockets;
using System.Text;

Console.WriteLine("Hello, World!");
UdpClient udpClient = new UdpClient();
udpClient.Client.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000));

var data = Encoding.UTF8.GetBytes("ABCD");
udpClient.Send(Encoding.UTF8.GetBytes("ABCD"), data.Length, "localhost", 11000);
var ipEndpoint = new IPEndPoint(IPAddress.Any, 11000);
var recesiveData = udpClient.Receive(ref ipEndpoint);


//"192.167.1.255" 0xFF   0-255    "192.168.1.0"  "255.255.255.0"  "192.168.1.255"
// "192.168.1.0"  "255.255.0.0"  "192.168.255.255"