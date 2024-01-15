using CreditCards.Server.Helper;
using CreditCards.Server.Helper.Interfaces;
using CreditCards.Server.Models.Cards;

namespace CreditCards.Server.Handler
{
    public class AMEXCardHandler(ILuhnValidator luhnValidator) : BaseInputHandler(luhnValidator)
    {

        public override bool CanConvert(string input)
        {
            return input.Length == 15 && (input[..2] == "34" || input[..2] == "37");
        }

        public override BaseCard GenerateCard(string input)
        {
            return new AMEX(input, luhnValidator);
        }
    }
}
