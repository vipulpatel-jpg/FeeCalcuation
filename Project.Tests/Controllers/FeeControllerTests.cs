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

    [Fact]
    public void Calculate_NullTransaction_ReturnsBadRequest()
    {
        // Arrange
        var mockCalculator = new Mock<IFeeCalculator>();
        var controller = new FeeController(mockCalculator.Object);

        // Act
        var result = controller.Calculate(null);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public void Calculate_InvalidModelState_ReturnsBadRequest()
    {
        // Arrange
        var mockCalculator = new Mock<IFeeCalculator>();
        var controller = new FeeController(mockCalculator.Object);
        var transaction = new Transaction { Amount = -100, Currency = "EUR" };

        // Simulate ModelState error
        controller.ModelState.AddModelError("Amount", "Amount must be between 0.01 and 999,999,999.99");

        // Act
        var result = controller.Calculate(transaction);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }
}
