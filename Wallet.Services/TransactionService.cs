using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WalletApp.Abstractions.Services;
using WalletApp.Models.DTO;

namespace WalletApp.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TransactionService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<double?> ConvertCurrency(string currencyToConvert, double amount)
        {
            var convAmount = 0.00;
            try
            {
                var httpClient = _httpClientFactory.CreateClient();
                var conversionStr = "https://open.er-api.com/v6/latest/NGN";
                using (var response = await httpClient.GetAsync(conversionStr, HttpCompletionOption.ResponseHeadersRead))
                {
                    response.EnsureSuccessStatusCode();
                    var stream = await response.Content.ReadAsStreamAsync();
                    var newRates = await JsonSerializer.DeserializeAsync<RatesDTO>(stream);
                    var rate = newRates.rates[currencyToConvert];
                    convAmount = rate * amount;
                }
            }

            catch (Exception ex)
            {
                return null;
            }
            return convAmount;
        }
    }
}
