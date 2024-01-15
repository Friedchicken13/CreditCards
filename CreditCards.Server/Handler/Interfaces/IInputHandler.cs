using CreditCards.Server.Models.Cards;
using System.Reflection.Metadata;

namespace CreditCards.Server.Handler.Interfaces
{
    public interface IInputHandler
    {
        void SetNextHandler(IInputHandler inputHandler);

        BaseCard Handle(string request);
    }
}
