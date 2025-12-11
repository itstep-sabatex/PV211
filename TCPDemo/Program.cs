// See https://aka.ms/new-console-template for more information
using System;
using System.Net;
using System.Net.Sockets;

Console.WriteLine("Hello, World!");

void ClientRun(string taskName)
{
    var client = new TcpClient("127.0.0.1", 11000);
    var message = $"Hello Server from task {taskName}!!!";
    byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
    NetworkStream stream = client.GetStream();
    stream.Write(data, 0, data.Length);
    Console.WriteLine("Sent: {0}", message);
    data = new Byte[256];
    // Read the first batch of the TcpServer response bytes.
    Int32 bytes = stream.Read(data, 0, data.Length);
    var responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
    Console.WriteLine("Received: {0}", responseData);

    stream.Close();
    client.Close();
}


var tcpClient = Task.Run(() => 
{
    for (int i = 0; i < 10; i++)
    {
       Task.Run(()=>ClientRun(i.ToString()));
    }



    var client = new TcpClient("127.0.0.1", 11000);
    var message = "Hello Server!!!";
    byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
    NetworkStream stream = client.GetStream();
    stream.Write(data, 0, data.Length);
    Console.WriteLine("Sent: {0}", message);
    data = new Byte[256];
    // Read the first batch of the TcpServer response bytes.
    Int32 bytes = stream.Read(data, 0, data.Length);
    var responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
    Console.WriteLine("Received: {0}", responseData);
    
    stream.Close();
    client.Close();

});

var tcpServer = Task.Run(() =>
{
    var ipAddr = new IPAddress(new byte[] { 127, 0, 0, 1 });

    var server = new TcpListener(ipAddr, 11000);
    server.Start();
    while (true)
    {
        Console.Write("Waiting for a connection... ");
        TcpClient client = server.AcceptTcpClient();
        Console.WriteLine("Connected!");
        Task.Run(() =>
        {
            var data = new Byte[256];
            // Read the first batch of the TcpServer response bytes.
            NetworkStream stream = client.GetStream();
            Int32 bytes = stream.Read(data, 0, data.Length);
            var responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            Console.WriteLine("Received: {0}", responseData);
            var message = "Hello Server!!!";
            data = System.Text.Encoding.ASCII.GetBytes(message);
            Thread.Sleep(5000);
            stream.Write(data, 0, data.Length);
            Console.WriteLine("Sent: {0}", message);
            client.Close();
        });
    }
  
    
 

});



Console.ReadLine();