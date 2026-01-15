namespace Tests;

using String_Calculator;
using Xunit;

public class StringCalculatorTest
{
    [Theory]
    [InlineData(0, "")]
    [InlineData(1, "1")]
    [InlineData(3, "1,2")]
    [InlineData(25, "5,5,5,5,5")]
    [InlineData(2, "1\n1")]
    [InlineData(4, "1,1\n2")]
    [InlineData(2, "1,1,\n")]

    public void Add_With_Default_Separator(int expected, string numbers)
    {
        int result = StringCalculator.Add(numbers);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(2, "//;\n1;1")]
    [InlineData(2, "//[\n1[1")]
    public void Add_With_Custom_Separator(int expected, string numbers)
    {
        int result = StringCalculator.Add(numbers);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(2, "//[;;]\n1;;1")]
    [InlineData(2, "//[,,,]\n1,,,1")]
    public void Add_With_Custom_Separator_Two(int expected, string numbers)
    {
        int result = StringCalculator.Add(numbers);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(3, "//[;][.]\n1;1.1")]
    [InlineData(3, "//[,,,][-]\n1,,,1-1")]
    public void Add_With_Custom_Separator_three(int expected, string numbers)
    {
        int result = StringCalculator.Add(numbers);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("Negatives not allowed: -1", "-1")]
    [InlineData("Negatives not allowed: -1,-2", "1,-1,-2")]
    public void Add_With_Negative_Numbers(string expectedMessage, string numbers)
    {
        var exception = Assert.Throws<ArgumentException>(() => StringCalculator.Add(numbers));
        Assert.Equal(expectedMessage, exception.Message);
    }

    [Theory]
    [InlineData(2, "1000,2")]
    [InlineData(2, "1000,2,31000")]
    public void Add_Without_1000_Or_Bigger(int expected, string numbers)
    {
        int result = StringCalculator.Add(numbers);
        Assert.Equal(expected, result);
    }

}
