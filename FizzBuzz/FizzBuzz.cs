namespace FizzBuzz;

public static class FizzBuzz
{
    public static string Run(int i)
    {
        bool isFizz = i % 3 == 0 || i.ToString().Contains('3');
        bool isBuzz = i % 5 == 0 || i.ToString().Contains('5');

        if (isFizz && isBuzz) return "FizzBuzz";
        if (isFizz) return "Fizz";
        if (isBuzz) return "Buzz";
        return i.ToString();
    }
}
