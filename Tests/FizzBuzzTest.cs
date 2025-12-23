namespace Tests;

using FizzBuzz;
using Xunit;

public class FizzBuzzTest
{
    [Theory]
    [InlineData(3, "Fizz")]    // Divisível por 3
    [InlineData(13, "Fizz")]   // Contém 3
    public void Should_Return_Fizz(int input, string expected)
    {
        string result = FizzBuzz.Run(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(5, "Buzz")]    // Divisível por 5
    [InlineData(52, "Buzz")]   // Contém 5
    public void Should_Return_Buzz(int input, string expected)
    {
        string result = FizzBuzz.Run(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(15, "FizzBuzz")] // Divisível por 3 e 5
    [InlineData(35, "FizzBuzz")] // Contém 3 e 5
    [InlineData(51, "FizzBuzz")] // Divisível por 3 e contém 5
    public void Should_Return_FizzBuzz(int input, string expected)
    {
        string result = FizzBuzz.Run(input);
        Assert.Equal(expected, result);
    }
}

