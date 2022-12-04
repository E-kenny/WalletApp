using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WalletApp.Abstractions.Repositories;
using WalletApp.Abstractions.Services;
using WalletApp.Models.DTO;

namespace WalletApp.Services
{
    public class WalletService : IWalletService
    {
        private readonly IWalletRepository _walletRepository;

        public WalletService(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }
        
        public async Task<string> CreateWalletAsync()
        {
            var address = await _walletRepository.CreateWalletAsync();
            return address;
        }

        public async Task<bool> DepositAsync(DepositDto deposit)
        {
            if(deposit.Amount < 1) return false;
            var deposited = await _walletRepository.DepositAsync(deposit);
            return deposited;   
        }

        public Task<bool> WithdrawAsync(double amount, WalletDTO walletDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> TransferAsync(double amount, WalletDTO walletDTOSender, WalletDTO walletDTOReciever)
        {
            throw new NotImplementedException();
        }

        public Task<double> GetBalanceAsync(string walletAddress)
        {
            throw new NotImplementedException();
        }
    }
}
