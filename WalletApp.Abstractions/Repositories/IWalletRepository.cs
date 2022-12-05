using WalletApp.Models.DTO;
using WalletApp.Models.Entities;

namespace WalletApp.Abstractions.Repositories
{
    public interface IWalletRepository
    {
        public Task<string> CreateWalletAsync();
        
        public Task<bool> DepositAsync(DepositDto deposit);
        public Task<bool> WithdrawAsync(double amount, WalletDTO walletDTO);
        public Task<bool> TransferAsync(TransferDto transfer);
        public Task<double?> GetBalanceAsync(string walletAddress);
        public Task<List<Wallet>> GetListOfWallets();

    }
}