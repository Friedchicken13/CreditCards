using CreditCards.Server.Models.Cards;

namespace CreditCards.Server.Helper.Interfaces
{
    public interface ICardSelector
    {
        BaseCard GetType(string cardNumber);
    }
}
