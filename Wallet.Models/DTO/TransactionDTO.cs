using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletApp.Models.DTO
{
    public enum Type
    {
        Debit, Credit
    }
    public class TransactionDTO
    {
        public int Id { get; set; }
        public Type Type { get; set; }
        public int WalletId { get; set; }
        public double Amount { get; set; }
        public double Balance { get; set; }
    }
}
