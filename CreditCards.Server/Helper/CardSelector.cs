using CreditCards.Server.Helper.Interfaces;
using CreditCards.Server.Models.Cards;
using CreditCards.Server.Services.Interfaces;

namespace CreditCards.Server.Helper
{
    public class CardSelector(ILuhnValidator luhnValidator) : ICardSelector
    {
        private readonly ILuhnValidator _luhnValidator = luhnValidator;

        public BaseCard GetType(string cardNumber) 
        {
            if (cardNumber.Length == 15 && (cardNumber[..2] == "34" || cardNumber[..2] == "37"))
                return new AMEX(cardNumber, _luhnValidator);
            else if (cardNumber.Length == 16 && cardNumber[..4] == "6011")
                return new Discover(cardNumber, _luhnValidator);
            else if (cardNumber.Length == 16 && int.TryParse(cardNumber[..2], out int cardStartsWith) && cardStartsWith >= 51 && cardStartsWith <= 55)
                return new MasterCard(cardNumber, _luhnValidator);
            else if ((cardNumber.Length == 13 || cardNumber.Length == 16) && cardNumber[..1] == "4")
                return new Visa(cardNumber, _luhnValidator);
            else
                return new InvalidCard(cardNumber, _luhnValidator);
        }
    }
}
