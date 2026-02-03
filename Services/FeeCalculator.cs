public class FeeCalculator : IFeeCalculator
{
    public FeeResult Calculate(Transaction transaction)
    {
        return new FeeResult { Fee = 0 };
    }
}
