using WalletApp.Models.DTO;
using WalletApp.Models.Entities;

namespace WalletApp.Utils
{
    public class WalletAppMapper
    {
        public static WalletDTO ModelToDTO(Wallet model)
        {
            var walletDTO = new WalletDTO();
            walletDTO.Address = model.Address;
            walletDTO.UserId = model.UserId;
            walletDTO.Balance = model.Balance;
            walletDTO.Id = model.Id;

            return walletDTO;
        }

        public static Wallet DTOToModel(WalletDTO model)
        {
            var wallet = new Wallet();
            wallet.UserId = model.UserId;
            wallet.Balance = model.Balance;
            wallet.Address = model.Address;
            wallet.Id = model.Id;

            return wallet;
        }
    }
}