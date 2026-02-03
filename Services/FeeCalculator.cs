public class FeeCalculator : IFeeCalculator
{
    public FeeResult Calculate(Transaction transaction)
    {
        if (transaction == null)
        {
            throw new ArgumentNullException(nameof(transaction), "Transaction cannot be null");
        }

        return new FeeResult { Fee = ((transaction.Amount * 10) / 100) };
    }
}