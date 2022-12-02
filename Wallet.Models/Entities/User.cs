using Microsoft.AspNetCore.Identity;

namespace WalletApp.Models.Entities
{
    public class User:IdentityUser
    {
        public String Name { get; set; }
        public ICollection<Wallet> wallets { get; set; }
    }
}