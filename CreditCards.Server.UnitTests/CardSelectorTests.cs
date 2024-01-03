using CreditCards.Server.Helper;
using CreditCards.Server.Helper.Interfaces;
using CreditCards.Server.Models.Cards;
using Moq;

namespace CreditCards.Server.UnitTests
{
    public class CardSelectorTests
    {
        private readonly CardSelector _cardSelector;
        private readonly Mock<ILuhnValidator> mockILuhnValidator = new();

        public CardSelectorTests() {
            _cardSelector = new CardSelector(mockILuhnValidator.Object);
        }
        [Theory]
        [InlineData("378282246310005")]
        public void GetType_WithValidAmexRequest_ReturnsAmexCard(string cardNumber)
        {
            var result = _cardSelector.GetType(cardNumber);
            Assert.IsType<AMEX>(result);
            Assert.Equal("AMEX",result.GetName());
            Assert.Equal(cardNumber, result.GetCardNumber());
        }

        [Theory]
        [InlineData("4111111111111111")]
        [InlineData("4111111111111")]
        [InlineData("4012888888881881")]
        public void GetType_WithValidVisaRequest_ReturnsVisaCard(string cardNumber)
        {
            var result = _cardSelector.GetType(cardNumber);
            Assert.IsType<Visa>(result);
            Assert.Equal("Visa", result.GetName());
            Assert.Equal(cardNumber, result.GetCardNumber());
        }

        [Theory]
        [InlineData("6011111111111117")]
        public void GetType_WithValidDiscoverRequest_ReturnsDiscoverCard(string cardNumber)
        {
            var result = _cardSelector.GetType(cardNumber);
            Assert.IsType<Discover>(result);
            Assert.Equal("Discover", result.GetName());
            Assert.Equal(cardNumber, result.GetCardNumber());
        }

        [Theory]
        [InlineData("5105105105105100")]
        [InlineData("5105105105105106")]
        public void GetType_WithValidMasterCardRequest_ReturnsMasterCard(string cardNumber)
        {
            var result = _cardSelector.GetType(cardNumber);
            Assert.IsType<MasterCard>(result);
            Assert.Equal("MasterCard", result.GetName());
            Assert.Equal(cardNumber, result.GetCardNumber());
        }

        [Theory]
        [InlineData("9111111111111111")]
        [InlineData("")]
        [InlineData("            ")]
        public void GetType_WithInvalidCardRequest_ReturnsInvalidCard(string cardNumber)
        {
            var result = _cardSelector.GetType(cardNumber);
            Assert.IsType<InvalidCard>(result);
            Assert.Equal("Unknown", result.GetName());
            Assert.Equal(cardNumber, result.GetCardNumber());
        }
    }
}