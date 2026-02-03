using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Project.Tests.Controllers;

public class FeeControllerTests
{
    [Fact]
    public void Calculate_ValidTransaction_ReturnsOkResult()
    {
        // Arrange
        var mockCalculator = new Mock<IFeeCalculator>();
        mockCalculator.Setup(x => x.Calculate(It.IsAny<Transaction>()))
            .Returns(new FeeResult { Fee = 0, Currency = "EUR" });

        var controller = new FeeController(mockCalculator.Object);
        var transaction = new Transaction { Amount = 100, Currency = "EUR" };

        // Act
        var result = controller.Calculate(transaction);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void Calculate_ValidTransaction_CallsFeeCalculator()
    {
        // Arrange
        var mockCalculator = new Mock<IFeeCalculator>();
        mockCalculator.Setup(x => x.Calculate(It.IsAny<Transaction>()))
            .Returns(new FeeResult { Fee = 0, Currency = "EUR" });

        var controller = new FeeController(mockCalculator.Object);
        var transaction = new Transaction { Amount = 100, Currency = "EUR" };

        // Act
        controller.Calculate(transaction);

        // Assert
        mockCalculator.Verify(x => x.Calculate(transaction), Times.Once);
    }

    [Fact]
    public void Calculate_ValidTransaction_ReturnsFeeResult()
    {
        // Arrange
        var expectedResult = new FeeResult { Fee = 5, Currency = "EUR" };
        var mockCalculator = new Mock<IFeeCalculator>();
        mockCalculator.Setup(x => x.Calculate(It.IsAny<Transaction>()))
            .Returns(expectedResult);

        var controller = new FeeController(mockCalculator.Object);
        var transaction = new Transaction { Amount = 100, Currency = "EUR" };

        // Act
        var result = controller.Calculate(transaction) as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedResult, result.Value);
    }
}
