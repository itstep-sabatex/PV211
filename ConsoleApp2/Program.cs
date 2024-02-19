// See https://aka.ms/new-console-template for more information
using MonitorDemo;

Console.WriteLine("Hello, World!");
for (int i = 0; i < 100; i++)
{
  var test = new TestMonitor();
  test.IncrementInTwoThread(100);
  Console.WriteLine(test.Counter);

}

