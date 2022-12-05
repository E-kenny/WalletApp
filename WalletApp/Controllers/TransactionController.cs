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
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("/convert")]
        public Task<double?> ConvertCurrency(string currencyToConvert, double amount)
        {
            throw new NotImplementedException();
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
                return NotFound();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
            
        }

        [HttpPost("/statement")]
        public async Task<IActionResult> GetWalletStatement(string Address)
        {
            try
            {
               var result = await _transactionService.GetWalletStatementAsync(Address);
                if(result!=null)
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
