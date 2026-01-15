namespace Greed;

public static class GreedKata
{
    private const int DICE_ROLLS = 5;

    public static (int, List<int>) Run()
    {
        int score = 0;
        List<int> numbers = [];

        for (int i = 0; i < DICE_ROLLS; i++)
        {
            numbers.Add(Dice.Roll());
        }

        IEnumerable<KeyValuePair<int, int>> counts = numbers.AggregateBy(
            keySelector: x => x,
            seed: 0,
            func: (count, _) => count + 1
            );

        foreach (var item in counts)
        {
            int number = item.Key;
            int count = item.Value;

            if (count >= 3)
            {
                if (number == 1)
                    score += 1000;
                else
                    score += number * 100;

                count -= 3;
            }

            if (number == 1)
                score += count * 100;
            else if (number == 5)
                score += count * 50;
        }

        return (score, numbers);
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
