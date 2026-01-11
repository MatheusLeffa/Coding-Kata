namespace String_Calculator;

public class StringCalculator
{
    public static int Add(string numbers)
    {
        List<int> listOfNumbers = [.. ToListOfIntegers(numbers).Where(numbers => numbers < 1000)];
        List<int> negativeNumbers = [.. listOfNumbers.Where(number => number < 0)];

        if (listOfNumbers.Count == 0)
            return 0;

        if (negativeNumbers.Count > 0)
        {
            throw new ArgumentException("Negatives not allowed: " + string.Join(",", negativeNumbers));
        }

        return listOfNumbers.Sum();
    }


    #region Private Methods
    private static List<int> ToListOfIntegers(string numbers)
    {
        List<char> separators = [',', '\n'];
        int indexOfLineBreak = numbers.IndexOf('\n');

        if (numbers.StartsWith("//"))
        {
            SetSeparators(separators, numbers, indexOfLineBreak);
            numbers = numbers.Substring(indexOfLineBreak + 1);
        }

        return [.. numbers
            .Split(separators.ToArray(), StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Select(int.Parse)];
    }

    private static void SetSeparators(List<char> separators, string numbers, int stopIndex)
    {
        separators.Clear();

        if (stopIndex == 3)
        {
            separators.Add(numbers.ElementAt(stopIndex - 1));
            return;
        }

        for (int i = 0; i < stopIndex; i++)
        {
            if (numbers[i] == '[')
            {
                for (int n = i; n < stopIndex; n++)
                {
                    if (numbers[n] == ']')
                    {
                        i = n;
                        break;
                    }
                    separators.Add(numbers[n]);
                }
            }
        }
    }
    #endregion
}
