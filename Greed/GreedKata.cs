namespace Greed;

public static class GreedKata
{
    private const int DICE_ROLLS = 5;

    public static (int, List<int>) Run()
    {
        List<int> numbers = [];

        for (int i = 0; i < DICE_ROLLS; i++)
        {
            numbers.Add(Dice.Roll());
        }

        int one = numbers.Count(x => x == 1);
        int two = numbers.Count(x => x == 2);
        int three = numbers.Count(x => x == 3);
        int four = numbers.Count(x => x == 4);
        int five = numbers.Count(x => x == 5);
        int six = numbers.Count(x => x == 6);

        int result = 0;

        switch (one)
        {
            case 1:
                result = 100;
                break;
            case 3:
                result = 1000;
                break;
        }

        switch (two)
        {
            case 3:
                result = 200;
                break;
        }

        switch (three)
        {
            case 3:
                result = 300;
                break;
        }

        switch (four)
        {
            case 3:
                result = 400;
                break;
        }

        switch (five)
        {
            case 1:
                result = 50;
                break;
            case 3:
                result = 500;
                break;
        }

        switch (six)
        {
            case 3:
                result = 600;
                break;
        }

        return (result, numbers);
    }
}

public static class Dice
{
    private static readonly int[] Values = [1, 2, 3, 4, 5, 6];

    public static int Roll()
    {
        Random random = new();
        return Values[random.Next(Values.Length)];
    }
}
