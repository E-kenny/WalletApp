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

        [HttpGet("/transactions")]
        public Task<IEnumerable<TransactionDTO>> GetAllUserTransactions(int UserId)
        {
            throw new NotImplementedException();
        }

        [HttpGet("/statement")]
        public Task<IEnumerable<TransactionDTO>> GetWalletStatement(int WalletId)
        {
            throw new NotImplementedException();
        }
    }
}
