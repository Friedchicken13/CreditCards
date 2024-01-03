using CreditCards.Server.DTOs;
using CreditCards.Server.Helper;
using CreditCards.Server.Helper.Interfaces;
using CreditCards.Server.Models.Cards;
using CreditCards.Server.Services.Interfaces;

namespace CreditCards.Server.Services
{
    public class CreditCardService(ICardSelector cardSelector) : ICreditCardService
    {
        private readonly ICardSelector _cardSelector = cardSelector;

        public async Task<CreditCardDetailsDTO> GetCreditCardType(string cardNumber)
        {
            try
            {
                var result  = await Task.Run(() => _cardSelector.GetType(cardNumber));
                return new CreditCardDetailsDTO()
                {
                    CardNumber = result.GetCardNumber(),
                    IsValid = result.IsValid(),
                    Type = result.GetName()
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
