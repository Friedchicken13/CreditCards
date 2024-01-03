using CreditCards.Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CreditCards.Server.Controllers
{

    [ApiController]
    [Route("CreditCard")]
    public class CreditCardController(ICreditCardService creditCardService) : ControllerBase    
    {
        private readonly ICreditCardService _creditCardService = creditCardService;

        [HttpGet("CheckCard/{cardNumber}")]
        public async Task<IActionResult> CheckCard(string? cardNumber)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cardNumber))
                    return BadRequest("Cardnumber must not be empty!");

                var result = await _creditCardService.GetCreditCardType(cardNumber);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
            
        }
    }
}
