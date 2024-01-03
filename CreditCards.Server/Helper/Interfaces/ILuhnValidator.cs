namespace CreditCards.Server.Helper.Interfaces
{
    public interface ILuhnValidator
    {
        bool IsValidCard(string cardNumber);
    }
}
