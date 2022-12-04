using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WalletApp.Abstractions.Repositories;
using WalletApp.Abstractions.Services;
using WalletApp.Models.DTO;
using WalletApp.Models.Entities;

namespace WalletApp.Infrastructure.Repository
{
    public class TransactionRepository:ITransactionRepository
    {
        private readonly WalletDbContext _context;

        public TransactionRepository(WalletDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<IEnumerable<Transaction>>> GetAllUserTransactions(WalletDTO model)
        {
            var listOfTransactions = new List<List<Transaction>>();
            var allWallet =_context.Wallets.Where(x => x.UserId == model.UserId);
               foreach(var wallet in allWallet) 
                {
                  var transaction = _context.Transactions.Where(x => x.WalletId == wallet.Id).ToList();
                  listOfTransactions.Add(transaction);
                }
                  await  _context.SaveChangesAsync();
            return listOfTransactions;
        }

        public async Task<IEnumerable<Transaction>> GetWalletStatement(WalletDTO model)
        {
            var result =  _context.Transactions.Where(x => x.WalletId == model.Id).ToList();
            await _context.SaveChangesAsync();
            return result;
        }
    }
}
