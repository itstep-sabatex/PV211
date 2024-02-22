// See https://aka.ms/new-console-template for more information

namespace MatrixTask;

using System;
using System.Reflection.Metadata.Ecma335;

public static class Matrix 
{ 








public static double[,] CreateMatrix(int dimension)
{
    var result = new double[dimension,dimension];
    for (int i = 0; i < dimension; i++)
    {
        for (int j = 0; j < dimension; j++)
        {
            result[i, j] = Random.Shared.NextDouble();
        }
    }
    return result;
}


static double  MultiplreOneElement(int dim,int i,int j, double[,] a, double[,] b)
{
    double result = 0;
    for (int mi = 0; mi < dim; mi++)
    {
        result = result + a[i, mi] * b[mi, j];
    }
    return result;
}

public static double[,] MultipleMatrix(int dim, double[,] a, double[,] b,Action<int> progress)
{
    var result = new double[dim,dim];
    for (int i = 0; i < dim; i++)
    {
        progress?.Invoke(i);
        for (int j = 0; j < dim; j++)
        {
            result[i,j] = MultiplreOneElement(dim, i, j, a, b);
        }
    }
    return result;
}


public static double[,] MultipleMatrixThreads(int dim, double[,] a, double[,] b)
{
    var threads = new Task<double>[dim, dim];
    var result = new double[dim, dim];
    for (int i = 0; i < dim; i++)
    {
        for (int j = 0; j < dim; j++)
        {
                threads[i,j] = Task<double>.Run(()=> MultiplreOneElement(dim, i, j, a, b));
        }
    }
        for (int i = 0; i < dim; i++)
        {
            for (int j = 0; j < dim; j++)
            {
                threads[i,j].Wait();
                result[i, j] = threads[i,j].Result;
            }
        }
    return result;
}

    static double[] MultiplreOneRow(int dim,int i, double[,] a, double[,] b)
{
    var result = new double[dim];
    for (int j = 0; j < dim; j++)
    {
            result[j] =MultiplreOneElement(dim, i, j, a,b);
    }
        return result;
}


public static double[,] MultiplreRows(int dim, double[,] a, double[,] b, Action<int> progress)
{
        var tasks = new Task<double[]>[dim];
        var result = new double[dim, dim];
        for (int i = 0; i < dim; i++)
        {
            var row = i;
            tasks[i] = Task<double[]>.Run(() => MultiplreOneRow(dim, row, a, b));
        }
        for (int i = 0; i < dim; i++)
        {
            progress?.Invoke(i);
            tasks[i].Wait();
            for (int j = 0; j < dim; j++) { result[i, j] = tasks[i].Result[j]; }
        }
        return result;
}

public static double[,] MultipleMatrix4Threads(int dim, double[,] a, double[,] b,Action rowCalc)
{

    var tasks = new Task[4];
    var result = new double[dim, dim];
    int last = dim / 4;
    for (int i = 0; i < 4; i++)
    {
        var ls = last* (i+1);
        if (i ==3)
        {
            ls = ls + dim % 4;
        }
            var start = i * last;

            tasks[i] = Task.Run(() =>{
                for (int i = start; i < ls; i++)
                {
                    for (int j = 0; j < dim; j++)
                    {
                        result[i, j] = MultiplreOneElement(dim, i, j, a, b);
                    }
                }
            });

    

    }
    foreach (var task in tasks) task.Wait();
    return result;
}

//double[,] MultipleMatrix8Threads(int dim, double[,] a, double[,] b)
//{
//    var threads = new List<Thread>();
//    var result = new double[dim, dim];
//    int last = dimension / 8;
//    for (int i = 0; i < 8; i++)
//    {
//        var ls = last * (i + 1);
//        if (i == 7)
//        {
//            ls = ls + dimension % 8;
//        }

//        var thread = new Thread(MultiplreRows);
//        thread.Start(new MatrixParams(dim, i * last, ls, a, b, result, null));
//        threads.Add(thread);

//    }
//    while (threads.Any(s => s.IsAlive)) { Thread.Sleep(10); }
//    return result;
//}



//void MethodA(object parameter)
//{
//    var a = parameter;
//    Console.WriteLine("Start Method A");
//    Thread.Sleep(3000);
//    Console.WriteLine("End Method A");
//}

////var a = CreateMatrix(dimension);
//var b = CreateMatrix(dimension);

//var elapsed = System.Diagnostics.Stopwatch.StartNew();
//var c = MultipleMatrix(dimension, a, b);
//elapsed.Stop();
//Console.WriteLine($"Calc Matrix with dimension {dimension} in main Thread - {elapsed.Elapsed}");

//elapsed = System.Diagnostics.Stopwatch.StartNew();
//c = MultipleMatrix4Threads(dimension, a, b);
//elapsed.Stop();
//Console.WriteLine($"Calc Matrix with dimension {dimension} in 4 Thread - {elapsed.Elapsed}");

//elapsed = System.Diagnostics.Stopwatch.StartNew();
//c = MultipleMatrix8Threads(dimension, a, b);
//elapsed.Stop();
//Console.WriteLine($"Calc Matrix with dimension {dimension} in 8 Thread - {elapsed.Elapsed}");

//elapsed = System.Diagnostics.Stopwatch.StartNew();
//c = MultipleMatrixThreadsRow(dimension, a, b);
//elapsed.Stop();
//Console.WriteLine($"Calc Matrix with dimension {dimension} in row  Thread - {elapsed.Elapsed}");

//elapsed = System.Diagnostics.Stopwatch.StartNew();
//c = MultipleMatrixThreads(dimension, a, b);
//elapsed.Stop();
//Console.WriteLine($"Calc Matrix with dimension {dimension} in multi Thread - {elapsed.Elapsed}");



//var tr = new Thread(MethodA);
//tr.Priority = ThreadPriority.BelowNormal;
//tr.IsBackground = true;
//tr.Start(10);
////tr.Suspend();
////tr.Resume();

//Thread.Sleep(1000);
//Console.WriteLine("End main thread");

    }