namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = int.Parse(args[0]);
            var b = int.Parse(args[1]);
            Environment.Exit(s + b);

        }
    }
}
