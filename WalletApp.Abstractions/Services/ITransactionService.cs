using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletApp.Abstractions.Services
{
    public interface ITransactionService
    {
        public Task<double?> ConvertCurrency(string currencyToConvert, double amount);

    }
}
