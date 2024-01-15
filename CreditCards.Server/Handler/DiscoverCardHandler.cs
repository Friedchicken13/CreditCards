using CreditCards.Server.Helper;
using CreditCards.Server.Helper.Interfaces;
using CreditCards.Server.Models.Cards;

namespace CreditCards.Server.Handler
{
    public class DiscoverCardHandler(ILuhnValidator luhnValidator) : BaseInputHandler(luhnValidator)
    {

        public override bool CanConvert(string input)
        {
            return input.Length == 16 && input[..4] == "6011";
        }

        public override BaseCard GenerateCard(string input)
        {
            return new Discover(input, luhnValidator);
        }
    }
}
