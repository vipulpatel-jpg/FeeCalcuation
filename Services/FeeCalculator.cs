public class FeeCalculator : IFeeCalculator
{
    public FeeResult Calculate(Transaction transaction)
    {
        return new FeeResult { Fee = ((transaction.Amount * 10) / 100) };
    }
}