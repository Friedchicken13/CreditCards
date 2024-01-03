using CreditCards.Server.Helper.Interfaces;

namespace CreditCards.Server.Models.Cards
{
    public class Discover(string cardNumber, ILuhnValidator luhnValidator) : BaseCard(cardNumber, luhnValidator)
    {
        public override string GetName()
        {
            return "Discover";
        }

    }
}
