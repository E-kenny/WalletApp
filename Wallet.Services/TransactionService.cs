using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WalletApp.Abstractions.Repositories;
using WalletApp.Abstractions.Services;
using WalletApp.Models.DTO;
using WalletApp.Models.Entities;

namespace WalletApp.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IHttpClientFactory _httpClientFactory;

        public TransactionService(ITransactionRepository transactionRepository, IHttpClientFactory httpClientFactory)
        {
            _transactionRepository = transactionRepository;
            _httpClientFactory = httpClientFactory;
        }
        
        public async Task<double?> ConvertCurrency(string currencyA, string currencyB, double amount)
        {
                try
                {
                    string conversion_result = string.Empty;
                    var httpClient = _httpClientFactory.CreateClient();
                    var conversionStr = $"https://v6.exchangerate-api.com/v6/033ce5eb6f40fe61f7080372/pair/{currencyA}/{currencyB}/{amount}";
                    using (var response = await httpClient.GetAsync(conversionStr, HttpCompletionOption.ResponseHeadersRead))
                    {
                        response.EnsureSuccessStatusCode();
                        var stream = await response.Content.ReadAsStreamAsync();
                        var newConvertDouble = await JsonSerializer.DeserializeAsync<ConvertDoubleDTO>(stream);
                        var newAmount = newConvertDouble.conversion_result;


                        return newAmount;
                    }

                }
                catch (Exception)
                {
                    return default;

                }

        }
        public async Task<double?> GetRate(string currencyCode, double amount)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient();
                var conversionStr = "https://open.er-api.com/v6/latest/NGN";
                using (var response = await httpClient.GetAsync(conversionStr, HttpCompletionOption.ResponseHeadersRead))
                {
                    response.EnsureSuccessStatusCode();
                    var stream = await response.Content.ReadAsStreamAsync();
                    var newRates = await JsonSerializer.DeserializeAsync<RatesDTO>(stream);
                    var rate = newRates.rates[currencyCode];
                    var convAmount = rate * amount;

                    return convAmount;
                }

            }
            catch (Exception)
            {
                return default;

            }
        }

        public async Task<IEnumerable<IEnumerable<Transaction>>> GetAllUserTransactions(WalletDTO model)
        {
           return await _transactionRepository.GetAllUserTransactions(model);
        }

        
        public async Task<IEnumerable<Transaction>> GetWalletStatement(WalletDTO model)
        {
            return await _transactionRepository.GetWalletStatement(model);
        }
    
    }
}
