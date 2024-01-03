using CreditCards.Server.Helper.Interfaces;

namespace CreditCards.Server.Models.Cards
{
    public class MasterCard(string cardNumber, ILuhnValidator luhnValidator) : BaseCard(cardNumber, luhnValidator)
    {
        public override string GetName()
        {
            return "MasterCard";
        }
    }
}
