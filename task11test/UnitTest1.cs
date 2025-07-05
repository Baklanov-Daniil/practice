using Xunit;
using System;

public class CalculatorTests
{
    private readonly dynamic _calculator;

    public CalculatorTests()
    {
        _calculator = CalculatorGenerator.CreateCalculator();
    }

    [Fact]
    public void Add_ShouldReturnCorrectSum()
    {
        int a = 6, b = 3;

        int result = _calculator.Add(a, b);

        Assert.Equal(9, result);
    }

    [Fact]
    public void Subtract_ShouldReturnCorrectDifference()
    {
        int a = 6, b = 3;

        int result = _calculator.Subtract(a, b);

        Assert.Equal(3, result);
    }

    [Fact]
    public void Multiply_ShouldReturnCorrectProduct()
    {
        int a = 6, b = 3;

        int result = _calculator.Multiply(a, b);

        Assert.Equal(18, result);
    }

    [Fact]
    public void Divide_ShouldReturnCorrectQuotient()
    {
        int a = 6, b = 3;

        int result = _calculator.Divide(a, b);
        Assert.Equal(2, result);
    }

    [Fact]
    public void Divide_ByZero_ShouldThrowDivideByZeroException()
    {
        int a = 5, b = 0;
        Assert.Throws<DivideByZeroException>(() => _calculator.Divide(a, b));
    }

    [Fact]
    public void Calculator_Instance_IsCreatedSuccessfully()
    {
        var calculator = CalculatorGenerator.CreateCalculator();
        Assert.NotNull(calculator);
        Assert.IsAssignableFrom<ICalculator>(calculator);
    }
}
