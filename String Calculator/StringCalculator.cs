namespace String_Calculator;

public class StringCalculator
{
    public static int Add(string numbers)
    {
        List<int> listOfNumbers = ToListOfIntegers(numbers);
        List<int> negativeNumbers = [];


        if (listOfNumbers.Count == 0)
            return 0;

        foreach (int number in listOfNumbers)
        {
            if (number < 0)
                negativeNumbers.Add(number);
        }

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

        if (numbers.StartsWith("//"))
        {
            int indexOfLineBreak = numbers.IndexOf('\n');
            separators.AddRange(numbers.Substring(2, indexOfLineBreak - 2).ToCharArray());
            numbers = numbers.Substring(indexOfLineBreak + 1);
        }

        return numbers
            .Split(separators.ToArray(), StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Select(int.Parse)
            .ToList();
    }
    #endregion
}
