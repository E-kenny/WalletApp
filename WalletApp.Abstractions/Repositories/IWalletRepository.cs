using WalletApp.Models.DTO;

namespace WalletApp.Abstractions.Repositories
{
    public interface IWalletRepository
    {
        public Task<WalletDTO> CreateWalletAsync(WalletDTO walletDTO);
        public string GetId();
        public Task<bool> DepositAsync(double amount, WalletDTO walletDTO);
        public Task<bool> WithdrawAsync(double amount, WalletDTO walletDTO);
        public Task<bool> TransferAsync(double amount, WalletDTO walletDTOSender, WalletDTO walletDTOReciever);
        public Task<double> GetBalanceAsync(int walletId);

    }
}