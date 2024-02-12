// See https://aka.ms/new-console-template for more information






double[,] CreateMatrix(int dimension)
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


static double MultiplreOneElement(int dim, int i, int j, double[,] a, double[,] b)
{
    double result = 0;
    //var xDim = a.GetLength(0);
    //var yDim = a.GetLength(1);

    for (int mi = 0; mi < dim; mi++)
    {
        result = result + a[i, mi] * b[mi, j];
    }
    return result;
}

double[,] MultipleMatrix(int dim, double[,] a, double[,] b)
{
    var result = new double[dim,dim];
    for (int i = 0; i < 10; i++)
    {
        for (int j = 0; j < 10; j++)
        {
            result[i, j] = MultiplreOneElement(10, i, j, a, b);
        }
    }
    return result;
}


void MethodA(object parameter)
{
    var a = parameter;
    Console.WriteLine("Start Method A");
    Thread.Sleep(3000);
    Console.WriteLine("End Method A");
}

var a = CreateMatrix(10);
var b = CreateMatrix(10);


var c = MultipleMatrix(10, a, b);





var tr = new Thread(MethodA);
tr.Priority = ThreadPriority.BelowNormal;
tr.IsBackground = true;
tr.Start(10);
//tr.Suspend();
//tr.Resume();

Thread.Sleep(1000);
Console.WriteLine("End main thread");


