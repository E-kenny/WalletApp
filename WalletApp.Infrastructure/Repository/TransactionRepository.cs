using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WalletApp.Abstractions.Repositories;
using WalletApp.Abstractions.Services;
using WalletApp.Models.DTO;
using WalletApp.Models.Entities;

namespace WalletApp.Infrastructure.Repository
{
    public class TransactionRepository:ITransactionRepository
    {
        private readonly WalletDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TransactionRepository(WalletDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        private string GetId() => _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

        public async Task<IEnumerable<IEnumerable<Transaction>>> GetAllUserTransactions(Wallet model)
        {
            var result = await _context.Wallets.FindAsync(GetId());
            if (result == null || GetId() != result.UserId)
            {
                return null;
            }

            //if (GetId() != result.UserId)
            //{
            //    return null;
            //}

            var listOfTransactions = new List<List<Transaction>>();
            var allWallet = _context.Wallets.Where(x => x.UserId == result.UserId);
            foreach (var wallet in allWallet)
            {
                var transaction = _context.Transactions.Where(x => x.WalletId == wallet.Id).ToList();
                listOfTransactions.Add(transaction);
            }
            await _context.SaveChangesAsync();
            return listOfTransactions;
        }

        public async Task<IEnumerable<Transaction>> GetWalletStatement(string walletAddress)
        {

        //    _context.Students
        //.Include(s => s.Enrollments)
        //    .ThenInclude(e => e.Course)
        //.AsNoTracking()
        //.FirstOrDefaultAsync(m => m.ID == id);




            var currentWallet = await _context.Wallets
                .Include(s => s.User)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.UserId == GetId());

            if (currentWallet == null || GetId() != currentWallet.UserId)
            {
                return null;
            }

            if (GetId() != currentWallet.UserId)
            {
                return null;
            }
            var result = _context.Transactions.Where(x => x.WalletId == currentWallet.Id).ToList();
            await _context.SaveChangesAsync();
            return result;
        }
    }
}
