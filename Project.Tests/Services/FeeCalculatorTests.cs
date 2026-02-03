using Xunit;

namespace Project.Tests.Services;

public class FeeCalculatorTests
{
    [Fact]
    public void Calculate_ValidTransaction_ReturnsFeeResult()
    {
        // Arrange
        var calculator = new FeeCalculator();
        var transaction = new Transaction { Amount = 100, Currency = "EUR" };

        // Act
        var result = calculator.Calculate(transaction);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<FeeResult>(result);
    }

    [Fact]
    public void Calculate_EurTransaction_ReturnsEurCurrency()
    {
        // Arrange
        var calculator = new FeeCalculator();
        var transaction = new Transaction { Amount = 100, Currency = "EUR" };

        // Act
        var result = calculator.Calculate(transaction);

        // Assert
        Assert.Equal("EUR", result.Currency);
    }

    [Fact]
    public void Calculate_GbpTransaction_ReturnsFeeResult()
    {
        // Arrange
        var calculator = new FeeCalculator();
        var transaction = new Transaction { Amount = 100, Currency = "GBP" };

        // Act
        var result = calculator.Calculate(transaction);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("EUR", result.Currency);
    }

    [Fact]
    public void Calculate_ValidTransaction_ReturnsCorrectFee()
    {
        // Arrange
        var calculator = new FeeCalculator();
        var transaction = new Transaction { Amount = 100, Currency = "EUR" };

        // Act
        var result = calculator.Calculate(transaction);

        // Assert
        Assert.Equal(10, result.Fee);
    }

    [Fact]
    public void Calculate_TokenTransaction_ReturnsFeeResult()
    {
        // Arrange
        var calculator = new FeeCalculator();
        var transaction = new Transaction
        {
            Amount = 100,
            Currency = "EUR",
            IsTokenTransaction = true
        };

        // Act
        var result = calculator.Calculate(transaction);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(10, result.Fee);
    }

    [Fact]
    public void Calculate_DecimalAmount_ReturnsDecimalFee()
    {
        // Arrange
        var calculator = new FeeCalculator();
        var transaction = new Transaction { Amount = 123.45m, Currency = "EUR" };

        // Act
        var result = calculator.Calculate(transaction);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(12.345m, result.Fee);
    }

    [Fact]
    public void Calculate_NullTransaction_ThrowsArgumentNullException()
    {
        // Arrange
        var calculator = new FeeCalculator();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => calculator.Calculate(null));
    }
}
