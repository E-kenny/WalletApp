using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletApp.Abstractions.Repositories;
using WalletApp.Models.DTO;

namespace WalletApp.Infrastructure.Repository
{
    public class WalletRepository:IWalletRepository
    {
        private readonly WalletDbContext _context;

        public WalletRepository(WalletDbContext context)
        {
            _context = context;
        }

        public Task<WalletDTO> CreateWalletAsync(WalletDTO walletDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DepositAsync(double amount, WalletDTO walletDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> WithdrawAsync(double amount, WalletDTO walletDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> TransferAsync(double amount, WalletDTO walletDTOSender, WalletDTO walletDTOReciever)
        {
            throw new NotImplementedException();
        }

        public Task<double> GetBalanceAsync(int walletId)
        {
            throw new NotImplementedException();
        }

    }
}
