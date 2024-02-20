// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Mutex mutex = new Mutex(false, "54A8B9A3-9C9A-4183-9800-A3B90015F94C", out bool isNew);

for (int i = 0; i < 100; i++)
{
    if (mutex.WaitOne(TimeSpan.FromSeconds(10)))
    {
        Console.WriteLine($"Counter {i}");
        Thread.Sleep(TimeSpan.FromSeconds(0.2));
        mutex.ReleaseMutex();

    }else
    {
        Console.WriteLine("Error, not enter ");
    }
}

