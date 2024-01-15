using CreditCards.Server.Helper;
using CreditCards.Server.Helper.Interfaces;
using CreditCards.Server.Models.Cards;

namespace CreditCards.Server.Handler
{
    public class MasterCardHandler(ILuhnValidator luhnValidator) : BaseInputHandler(luhnValidator)
    {

        public override bool CanConvert(string input)
        {
            return input.Length == 16 && int.TryParse(input[..2], out int cardStartsWith) && cardStartsWith >= 51 && cardStartsWith <= 55;
        }

        public override BaseCard GenerateCard(string input)
        {
            return new MasterCard(input, luhnValidator);
        }
    }
}
