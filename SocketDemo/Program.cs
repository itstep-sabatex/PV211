// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Net.Sockets;
using System.Text;

Console.WriteLine("Hello, World!");

IPAddress iPAddress = new IPAddress(new byte[] { 192, 168, 1, 1 });
iPAddress = IPAddress.Parse("192.168.1.1");



var google = Dns.GetHostAddresses("www.google.com");

IPEndPoint iPEndPoint = new IPEndPoint(google[0], 80);
var tSocket = new Socket(iPEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
tSocket.Connect(iPEndPoint);
var page = new StringBuilder();
if (tSocket.Connected)
{
    string request = $"GET / HTTP/1.1\r\nHost: www.google.com\r\nConnection: Close\r\n\r\n";
    var bytesSent = Encoding.ASCII.GetBytes(request);
    var bytesReceived = new byte[256];
    tSocket.Send(bytesSent);
    int bytes = 0;
    do
    {
        bytes = tSocket.Receive(bytesReceived,bytesReceived.Length,0);
        page.Append(Encoding.ASCII.GetString(bytesReceived, 0, bytes));
    }while (bytes > 0);
}

Console.WriteLine(page.ToString());