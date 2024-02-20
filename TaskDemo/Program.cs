// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

async Task<double> CalcAsync(double a, double b)
{
  
    return a + b;
}
Task<int> Calc(int a,int b)
{
    return Task.FromResult(a + b);
}


var r = await CalcAsync(2.5, 3);

var t =Task.Run(() => { });
var t2 =Task<int>.Run(() => { t.Wait(); return 1; });



var a = Calc(3, 4);
a.Wait();
Console.WriteLine(a.Result);