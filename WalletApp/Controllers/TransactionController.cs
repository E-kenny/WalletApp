using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WalletApp.Abstractions.Repositories;
using WalletApp.Abstractions.Services;
using WalletApp.Models.DTO;

namespace WalletApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ILogger<TransactionController> _logger;
        private readonly ITransactionService _transactionService;

        public TransactionController(ILogger<TransactionController> logger, ITransactionService transactionService)
        {
            _logger = logger;
            _transactionService = transactionService;
        }

        [HttpGet("/convert")]
        public async Task<IActionResult> ConvertCurrency(string currencyToConvert, double amount)
        {
            try{ 
               var result = await _transactionService.GetRateAsync(currencyToConvert, amount);
            return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Unable to Convert");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/conversion")]
        public async Task<IActionResult> CurrencyToCurrency(string currencyA, string currencyB, double amount)
        {
            try
            {
                var result = await _transactionService.ConvertCurrencyAsync(currencyA, currencyB, amount);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Unable to convert");
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("/transactions")]
        public async Task<IActionResult> GetAllUserTransactions()
        {
            try
            {
               var result =  await _transactionService.GetAllUserTransactionsAsync();
                if(result!=null)
                {
                    return Ok(result);
                }

                _logger.LogInformation("Could not get all user transaction");
                return NotFound();
            }
            catch (Exception ex)
            {
               
                return Problem(ex.Message);
            }
            
        }

        [HttpPost("/statement")]
        public async Task<IActionResult> GetWalletStatement(string Address, int page)
        {
            try
            {
               var result = await _transactionService.GetWalletStatementAsync(Address, page);
                if(result!=null)
                {
                    return Ok(result);
                }
                _logger.LogInformation("Could not get all wallet statement");
                return NotFound();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
