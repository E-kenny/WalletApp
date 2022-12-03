using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using WalletApp.Models.DTO;

namespace WalletApp.Abstractions.Services
{
    public interface ITransactionService
    {
        public Task<double?> ConvertCurrency(string currencyToConvert, double amount);
        public Task<IEnumerable<TransactionDTO>> GetAllUserTransactions(int UserId);
        public Task<IEnumerable<TransactionDTO>> GetWalletStatement(int WalletId);

    }
}
