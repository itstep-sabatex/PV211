// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Net.Sockets;
using System.Text;

var t1= Task.Run(() =>
{
    var ipAddress = IPAddress.Parse("127.0.0.1");
    IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

    var listner = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp); // TCP //UDP

    try
    {
        listner.Bind(localEndPoint);
        listner.Listen(10);
        do
        {
            Console.WriteLine($"Waiting for a connection in {localEndPoint}");
            Socket handler = listner.Accept();
            Console.WriteLine($"Connected {handler.RemoteEndPoint}");
            var bytesReceived = new byte[256];
            var page = new StringBuilder();
            int bytes = 0;
            do
            {
                bytes = handler.Receive(bytesReceived, bytesReceived.Length, 0);
                page.Append(Encoding.ASCII.GetString(bytesReceived, 0, bytes));
            } while (!page.ToString().EndsWith("EOF\r\n"));
            Console.WriteLine($"Server message: {page.ToString()}");
            string request = $"By\r\n";
            var bytesSent = Encoding.ASCII.GetBytes(request);
            handler.Send(bytesSent);
            handler.Close();
        } while (true);

    }
    catch (Exception e) { }
});

var t2 =Task.Run(() =>
{
    var ipAddress = IPAddress.Parse("127.0.0.1");
    IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);
    var tSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
    tSocket.Connect(localEndPoint);
    var page = new StringBuilder();
    if (tSocket.Connected)
    {
        string request = $"GET / HTTP/1.1\r\nHost: www.google.com\r\nConnection: Close\r\n\r\n EOF\r\n";
        var bytesSent = Encoding.ASCII.GetBytes(request);
        var bytesReceived = new byte[256];
        tSocket.Send(bytesSent);
        int bytes = 0;
        do
        {
            bytes = tSocket.Receive(bytesReceived, bytesReceived.Length, 0);
            page.Append(Encoding.ASCII.GetString(bytesReceived, 0, bytes));
        } while (bytes > 0);
        Console.WriteLine($"Client : {page.ToString()}");
    }

});


Console.ReadLine();