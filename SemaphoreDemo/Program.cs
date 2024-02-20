// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Semaphore mutex = new Semaphore(2,2,"9F633EE0-BD71-4F4C-A9DB-FFD865FC2D64", out bool isNew);

for (int i = 0; i < 100; i++)
{
    if (mutex.WaitOne(TimeSpan.FromSeconds(10)))
    {
        Console.WriteLine($"Counter {i}");
        Thread.Sleep(TimeSpan.FromSeconds(1));
        mutex.Release();

    }
    else
    {
        Console.WriteLine("Error, not enter ");
    }
}

