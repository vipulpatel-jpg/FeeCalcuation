using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/fees")]
public class FeeController : ControllerBase
{
    private readonly IFeeCalculator _feeCalculator;

    public FeeController(IFeeCalculator feeCalculator)
    {
        _feeCalculator = feeCalculator;
    }

    [HttpPost("calculate")]
    public IActionResult Calculate(Transaction transaction)
    {
        var result = _feeCalculator.Calculate(transaction);
        return Ok(result);
    }
}
