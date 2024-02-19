// See https://aka.ms/new-console-template for more information

namespace MatrixLib;
using ThreadDemo;
public class Matrix 
{ 



const int dimension = 1000;




public double[,] CreateMatrix(int dimension)
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


void MultiplreOneElement(object? param)
{
    if (param == null)
        throw new ArgumentNullException(nameof(param));
    MatrixParams matrixParams = (MatrixParams)param;
    double result = 0;
    for (int mi = 0; mi < matrixParams.dim; mi++)
    {
        result = result + matrixParams.a[matrixParams.i, mi] * matrixParams.b[mi, matrixParams.j];
    }
    matrixParams.c[matrixParams.i,matrixParams.j] = result;
}

public double[,] MultipleMatrix(int dim, double[,] a, double[,] b,Action<int> progress)
{
    var result = new double[dim,dim];
    for (int i = 0; i < dim; i++)
    {
        progress?.Invoke(i);
        for (int j = 0; j < dim; j++)
        {
            MultiplreOneElement(new MatrixParams(dim, i, j, a, b,result));
        }
    }
    return result;
}


double[,] MultipleMatrixThreads(int dim, double[,] a, double[,] b)
{
    var threads = new List<Thread>(dim*dim);
    var result = new double[dim, dim];
    for (int i = 0; i < dim; i++)
    {
        for (int j = 0; j < dim; j++)
        {
            var thread = new Thread(MultiplreOneElement);
            thread.Start(new MatrixParams(dim, i, j, a, b, result));
            threads.Add(thread);
        }
    }
    while (threads.Any(s => s.IsAlive)) { Thread.Sleep(10); }
    return result;
}

void MultiplreOneRow(object? param)
{
    if (param == null)
        throw new ArgumentNullException(nameof(param));
    MatrixParams matrixParams = (MatrixParams)param;
    for (int j = 0; j < matrixParams.dim; j++)
    {
        MultiplreOneElement(new MatrixParams(matrixParams.dim, matrixParams.i, j, matrixParams.a, matrixParams.b, matrixParams.c));
    }
}


void MultiplreRows(object? param)
{
    if (param == null)
        throw new ArgumentNullException(nameof(param));
    MatrixParams matrixParams = (MatrixParams)param;
    for (int i = matrixParams.i; i < matrixParams.j; i++)
    {

        for (int j = 0; j < matrixParams.dim; j++)
        {
            MultiplreOneElement(new MatrixParams(matrixParams.dim, matrixParams.i, j, matrixParams.a, matrixParams.b, matrixParams.c));
        }
    }
}


double[,] MultipleMatrixThreadsRow(int dim, double[,] a, double[,] b)
{
    var threads = new List<Thread>();
    var result = new double[dim, dim];
    for (int i = 0; i < dim; i++)
    {
            var thread = new Thread(MultiplreOneRow);
            thread.Start(new MatrixParams(dim, i, 0, a, b, result));
            threads.Add(thread);
        
    }
    while (threads.Any(s => s.IsAlive)) { Thread.Sleep(10); }
    return result;
}


double[,] MultipleMatrix4Threads(int dim, double[,] a, double[,] b)
{
    var threads = new List<Thread>();
    var result = new double[dim, dim];
    int last = dimension / 4;
    for (int i = 0; i < 4; i++)
    {
        var ls = last* (i+1);
        if (i ==3)
        {
            ls = ls + dimension % 4;
        }
        
        var thread = new Thread(MultiplreRows);
        thread.Start(new MatrixParams(dim, i*last, ls, a, b, result));
        threads.Add(thread);

    }
    while (threads.Any(s => s.IsAlive)) { Thread.Sleep(10); }
    return result;
}

double[,] MultipleMatrix8Threads(int dim, double[,] a, double[,] b)
{
    var threads = new List<Thread>();
    var result = new double[dim, dim];
    int last = dimension / 8;
    for (int i = 0; i < 8; i++)
    {
        var ls = last * (i + 1);
        if (i == 7)
        {
            ls = ls + dimension % 8;
        }

        var thread = new Thread(MultiplreRows);
        thread.Start(new MatrixParams(dim, i * last, ls, a, b, result));
        threads.Add(thread);

    }
    while (threads.Any(s => s.IsAlive)) { Thread.Sleep(10); }
    return result;
}



void MethodA(object parameter)
{
    var a = parameter;
    Console.WriteLine("Start Method A");
    Thread.Sleep(3000);
    Console.WriteLine("End Method A");
}

//var a = CreateMatrix(dimension);
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