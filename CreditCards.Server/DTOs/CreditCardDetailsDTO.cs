namespace CreditCards.Server.DTOs
{
    public class CreditCardDetailsDTO
    {
        public string? Type { get; set; }
        public string? CardNumber { get; set; }
        public bool? IsValid { get; set; }
    }
}
