using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletApp.Models.DTO;
using WalletApp.Models.Entities;

namespace WalletApp.Abstractions.Services
{
    public interface ITransactionService
    {
        public Task<double?> ConvertCurrency(string currencyA,string currencyB, double amount);
        public Task<double?> GetRate(string currencyCode, double amount);

        public Task<IEnumerable<IEnumerable<Transaction>>> GetAllUserTransactions(WalletDTO model);
        public Task<IEnumerable<TransactionDTO>> GetWalletStatement(string walletAddress);

    }
}
