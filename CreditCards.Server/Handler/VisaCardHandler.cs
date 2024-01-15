using CreditCards.Server.Helper;
using CreditCards.Server.Helper.Interfaces;
using CreditCards.Server.Models.Cards;

namespace CreditCards.Server.Handler
{
    public class VisaCardHandler(ILuhnValidator luhnValidator) : BaseInputHandler(luhnValidator)
    {

        public override bool CanConvert(string input)
        {
            return (input.Length == 13 || input.Length == 16) && input[..1] == "4";
        }

        public override BaseCard GenerateCard(string input)
        {
            return new Visa(input, luhnValidator);
        }
    }
}
