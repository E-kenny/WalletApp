using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WalletApp.Abstractions.Repositories;
using WalletApp.Abstractions.Services;
using WalletApp.Models.DTO;

namespace WalletApp.Infrastructure.Repository
{
    public class TransactionRepository:ITransactionRepository
    {
        private readonly WalletDbContext _context;

        public TransactionRepository(WalletDbContext context)
        {
            _context = context;
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
