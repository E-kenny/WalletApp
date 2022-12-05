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
            wallet.Address = model.Address;
            return wallet;
        }

        public static TransactionDTO TransactioToDTO(Transaction transaction)
        {
            var transactionDTO = new TransactionDTO();
            transactionDTO.Id = transaction.Id;
            transactionDTO.WalletId = transaction.WalletId;
            transactionDTO.Type = (Models.DTO.Type)transaction.Type;
            transactionDTO.Amount = transaction.Amount;
            transactionDTO.Balance = transaction.Balance;
            return transactionDTO;
        }
    }
}