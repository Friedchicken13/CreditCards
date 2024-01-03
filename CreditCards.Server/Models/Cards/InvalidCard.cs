using CreditCards.Server.Helper.Interfaces;

namespace CreditCards.Server.Models.Cards
{
    public class InvalidCard(string cardNumber, ILuhnValidator luhnValidator) : BaseCard(cardNumber, luhnValidator)
    {
        public override string GetName()
        {
            return "Unknown";
        }
        public override bool IsValid()
        {
            return false;
        }
    }
}
