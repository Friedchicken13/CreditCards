using CreditCards.Server.Helper.Interfaces;

namespace CreditCards.Server.Models.Cards
{
    public class Visa(string cardNumber, ILuhnValidator luhnValidator) : BaseCard(cardNumber, luhnValidator)
    {
        public override string GetName()
        {
            return "Visa";
        }
    }
}
