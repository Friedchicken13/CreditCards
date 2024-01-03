using CreditCards.Server.Helper.Interfaces;

namespace CreditCards.Server.Models.Cards
{
    public abstract class BaseCard
    {
        private readonly string _cardNumber;
        private readonly ILuhnValidator _luhnValidator;


        protected BaseCard(string cardNumber,ILuhnValidator luhnValidator)
        {
            _cardNumber = cardNumber;
            _luhnValidator = luhnValidator;
        }


        public abstract string GetName();

        public string GetCardNumber()
        {
            return _cardNumber;
        }

        public virtual bool IsValid() 
        {
            return _luhnValidator.IsValidCard(_cardNumber);
        } 
    }
}
