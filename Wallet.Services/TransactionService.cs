using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using WalletApp.Abstractions.Repositories;
using WalletApp.Abstractions.Services;
using WalletApp.Models.DTO;

namespace WalletApp.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public Task<double?> ConvertCurrency(string currencyToConvert, double amount)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TransactionDTO>> GetAllUserTransactions(int UserId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TransactionDTO>> GetWalletStatement(int WalletId)
        {
            throw new NotImplementedException();
        }
    }
}
