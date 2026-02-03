public interface IFeeCalculator
{
    FeeResult Calculate(Transaction transaction);
}
