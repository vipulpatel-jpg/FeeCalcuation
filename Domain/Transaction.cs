using System.ComponentModel.DataAnnotations;

public class Transaction
{
    [Required(ErrorMessage = "Amount is required")]
    [Range(0.01, 999999999.99, ErrorMessage = "Amount must be between 0.01 and 999,999,999.99")]
    public decimal Amount { get; set; }

    [Required(ErrorMessage = "Currency is required")]
    [StringLength(3, MinimumLength = 3, ErrorMessage = "Currency must be exactly 3 characters")]
    [RegularExpression(@"^[A-Z]{3}$", ErrorMessage = "Currency must be 3 uppercase letters (ISO 4217)")]
    public string Currency { get; set; } = "EUR";

    [StringLength(50, ErrorMessage = "Type cannot exceed 50 characters")]
    [RegularExpression(@"^[a-zA-Z0-9_-]*$", ErrorMessage = "Type contains invalid characters")]
    public string Type { get; set; } = "";

    public bool IsTokenTransaction { get; set; }
}
