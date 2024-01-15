using CreditCards.Server.Handler.Interfaces;
using CreditCards.Server.Helper.Interfaces;
using CreditCards.Server.Models.Cards;

namespace CreditCards.Server.Handler
{
    public abstract class BaseInputHandler(ILuhnValidator luhnValidator) : IInputHandler
    {
        private IInputHandler? _inputHandler;
        

        public void SetNextHandler(IInputHandler inputHandler)
        {
            _inputHandler = inputHandler;

        }
        public BaseCard Handle(string request)
        {
            if (CanConvert(request))
            {
                return GenerateCard(request);
            }
            else if (_inputHandler !=null)
            {
                return _inputHandler.Handle(request);
            }
            else
            {
                return new InvalidCard(request, luhnValidator);
            }
        }

        public abstract bool CanConvert(string input);
        public abstract BaseCard GenerateCard(string input);

    }
}
