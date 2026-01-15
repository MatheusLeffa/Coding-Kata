namespace Greed;

internal class Program
{
    private static void Main()
    {
        (int, List<int>) resultado = GreedKata.Run();

        Console.WriteLine(resultado.Item1);

        foreach (int x in resultado.Item2)
        {
            Console.Write(x + ", ");
        }
    }
}