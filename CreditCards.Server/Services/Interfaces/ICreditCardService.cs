using CreditCards.Server.DTOs;
using CreditCards.Server.Models.Cards;

namespace CreditCards.Server.Services.Interfaces
{
    public interface ICreditCardService
    {
        public Task<CreditCardDetailsDTO> GetCreditCardType(string cardNumber);
    }
}
