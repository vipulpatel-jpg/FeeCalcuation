using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/fees")]
public class FeeController : ControllerBase
{
    private readonly IFeeCalculator _feeCalculator;

    public FeeController(IFeeCalculator feeCalculator)
    {
        _feeCalculator = feeCalculator ?? throw new ArgumentNullException(nameof(feeCalculator));
    }

    [HttpPost("calculate")]
    [ProducesResponseType(typeof(FeeResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Calculate([FromBody] Transaction transaction)
    {
        // Null check
        if (transaction == null)
        {
            return BadRequest(new { error = "Transaction cannot be null" });
        }

        // Model validation
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var result = _feeCalculator.Calculate(transaction);
            return Ok(result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
        catch (Exception)
        {
            return StatusCode(500, new { error = "An error occurred processing your request" });
        }
    }
}
