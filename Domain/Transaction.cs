public class Transaction
{
    public decimal Amount { get; set; }
    public string Currency { get; set; } = "EUR";
    public string Type { get; set; } = "";
    public bool IsTokenTransaction { get; set; }
}
