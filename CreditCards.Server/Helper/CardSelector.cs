using CreditCards.Server.Handler;
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
            var inputHandler = new AMEXCardHandler(_luhnValidator);
            var discoverHandler = new DiscoverCardHandler(_luhnValidator);
            var masterCardHandler = new MasterCardHandler(_luhnValidator);
            var visaCardHandler = new VisaCardHandler(_luhnValidator);
            inputHandler.SetNextHandler(discoverHandler);
            discoverHandler.SetNextHandler(masterCardHandler);
            masterCardHandler.SetNextHandler(visaCardHandler);

            return inputHandler.Handle(cardNumber);
            //if (IsAmex(cardNumber))
            //    return new AMEX(cardNumber, _luhnValidator);
            //else if (IsDiscover(cardNumber))
            //    return new Discover(cardNumber, _luhnValidator);
            //else if (IsMasterCard(cardNumber))
            //    return new MasterCard(cardNumber, _luhnValidator);
            //else if(IsVisa(cardNumber))
            //    return new Visa(cardNumber, _luhnValidator);
            //else
            //    return new InvalidCard(cardNumber, _luhnValidator);
        }
    }

   
    
    
}
