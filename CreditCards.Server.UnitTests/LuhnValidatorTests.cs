using CreditCards.Server.Helper.Interfaces;
using CreditCards.Server.Helper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditCards.Server.Models.Cards;

namespace CreditCards.Server.UnitTests
{
    public class LuhnValidatorTests
    {
        private readonly LuhnValidator _luhnValidator;        

        public LuhnValidatorTests()
        {
            _luhnValidator = new LuhnValidator();
        }

        [Theory]
        [InlineData("4111111111111111")]
        [InlineData("4012888888881881")]
        [InlineData("378282246310005")]
        [InlineData("6011111111111117")]
        [InlineData("5105105105105100")]

        public void IsValidCard_WithValidCardNumbers_ReturnsTrue(string cardNumber)
        {
            var result = _luhnValidator.IsValidCard(cardNumber);
            Assert.IsType<bool>(result);
            Assert.True(result);
            
        }

        [Theory]
        [InlineData("4111111111111")]
        [InlineData("5105105105105106")]
        [InlineData("9111111111111111")]
        [InlineData("")]
        [InlineData("911111111a111111")]

        public void IsValidCard_WithInvalidCardNumbers_ReturnsFalse(string cardNumber)
        {
            var result = _luhnValidator.IsValidCard(cardNumber);
            Assert.IsType<bool>(result);
            Assert.False(result);

        }
    }
}
