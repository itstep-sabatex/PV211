// See https://aka.ms/new-console-template for more information

using System.Diagnostics;

var s = args.Count();


using (Process process = new Process())
{
    process.StartInfo.FileName = "cmd.exe";
    var folder =Directory.GetCurrentDirectory();
    process.StartInfo.Arguments = $"/C C:\\Users\\serhi\\source\\repos\\sabatex-itstep\\PV211\\ConsoleApp1\\bin\\Debug\\net8.0\\ConsoleApp1.exe 34 67";
    process.StartInfo.RedirectStandardOutput = true;
    process.StartInfo.RedirectStandardError = true;
    process.StartInfo.WorkingDirectory = folder;
    process.OutputDataReceived += (sender, e) =>
    {
        Console.WriteLine(e.Data);
    };
    process.ErrorDataReceived += (sender, e) =>
    {
        Console.WriteLine($"Помилка: {e.Data}");
    };


    process.Start();
    process.WaitForExit();

    var result = process.ExitCode;
    
    if (result != 0)
    {
        Console.WriteLine("Process has Error");
    }
    //return 2;
    Environment.Exit(4);
}

