using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletApp.Abstractions.Repositories;
using WalletApp.Models.DTO;
using WalletApp.Models.Entities;

namespace WalletApp.Infrastructure.Repository
{
    public class WalletRepository:IWalletRepository
    {
        private readonly WalletDbContext _context;

        public WalletRepository(WalletDbContext context)
        {
            _context = context;
        }

        public async Task<WalletDTO> CreateWalletAsync(WalletDTO walletDTO)
        {
            var address = GenerateAddress();
            var user = await _context.Users.Where(u => u.Id == walletDTO.UserId).FirstOrDefaultAsync();
            GenerateHash(address,out byte[] AddressHash, out byte[] AddressKey);
            var wallet = new Wallet();
            wallet.Address = address;
            return walletDTO;
        }

        public Task<bool> DepositAsync(double amount, WalletDTO walletDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> WithdrawAsync(double amount, WalletDTO walletDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> TransferAsync(double amount, WalletDTO walletDTOSender, WalletDTO walletDTOReciever)
        {
            throw new NotImplementedException();
        }

        public Task<double> GetBalanceAsync(int walletId)
        {
            throw new NotImplementedException();
        }

        private void GenerateHash(string address, out byte[] AddressHash, out byte[] AddressKey)
        {
            
            using (var hash = new System.Security.Cryptography.HMACSHA512())
            {
                AddressKey = hash.Key;
                AddressHash = hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(address));
            }
        }

        private bool VerifyAddress(string Address, byte[] AddressHash, byte[] AddressKey)
        {
            using (var hash = new System.Security.Cryptography.HMACSHA512(AddressKey))
            {
                var computedHash = hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Address));
                return computedHash.SequenceEqual(AddressHash);
            }
        }
        private string GenerateAddress()
        {
            var address = "0x";
            var str = "ZQAx0sewCq2SWFu7yhn1jEbgTokMI3KLOPml4DiGRptrB5H8YNJUfv6cXVd9az";
            var rnd = new Random();
            for (int i = 0; i < 23; i++)
            {
                address += str[rnd.Next(0, 61)];
            }
            return address;
        }

    }
}
