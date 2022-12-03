using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletApp.Models.DTO;

namespace WalletApp.Abstractions.Repositories
{
    public interface ITransactionRepository
    {
        public Task<IEnumerable<TransactionDTO>> GetWalletStatement(int WalletId);
        public Task<IEnumerable<TransactionDTO>> GetAllUserTransactions(int UserId);
    }
}
