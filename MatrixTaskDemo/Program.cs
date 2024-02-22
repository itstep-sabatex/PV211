// See https://aka.ms/new-console-template for more information
using MatrixTask;

var cn = Console.OpenStandardOutput();
await cn.WriteAsync(System.Text.Encoding.ASCII.GetBytes("Hello World"));

int dimension = 1000;
var a = Matrix.CreateMatrix(dimension);
var b = Matrix.CreateMatrix(dimension);

var elapsed = System.Diagnostics.Stopwatch.StartNew();
var c = Matrix.MultipleMatrix(dimension, a, b, (i) => { });
elapsed.Stop();
Console.WriteLine($"Calc Matrix with dimension {dimension} in main Thread - {elapsed.Elapsed}");

elapsed = System.Diagnostics.Stopwatch.StartNew();
c = Matrix.MultipleMatrix4Threads(dimension, a, b, () => { });
elapsed.Stop();
Console.WriteLine($"Calc Matrix with dimension {dimension} in 4 Thread - {elapsed.Elapsed}");

//elapsed = System.Diagnostics.Stopwatch.StartNew();
//c = MultipleMatrix8Threads(dimension, a, b);
//elapsed.Stop();
//Console.WriteLine($"Calc Matrix with dimension {dimension} in 8 Thread - {elapsed.Elapsed}");

elapsed = System.Diagnostics.Stopwatch.StartNew();
c = Matrix.MultiplreRows(dimension, a, b, (i) => { });
elapsed.Stop();
Console.WriteLine($"Calc Matrix with dimension {dimension} in row  Thread - {elapsed.Elapsed}");

//elapsed = System.Diagnostics.Stopwatch.StartNew();
//c = MultipleMatrixThreads(dimension, a, b);
//elapsed.Stop();
//Console.WriteLine($"Calc Matrix with dimension {dimension} in multi Thread - {elapsed.Elapsed}");
