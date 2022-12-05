using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WalletApp.Abstractions.Services;
using WalletApp.Models.DTO;

namespace WalletApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly IWalletService _walletService;
        private readonly IHttpContextAccessor httpContextAccessor;

        public WalletController(IWalletService walletService, IHttpContextAccessor httpContextAccessor)
        {
            _walletService = walletService;
            this.httpContextAccessor = httpContextAccessor;
        }
        [HttpGet]
        public async Task<ActionResult<string>> CreateAddress()
        {
            var response = await _walletService.CreateWalletAsync();
            if(response == "Failed") return Unauthorized("You must be loggedIn to Create a Wallet");
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<string>> Deposit(DepositDto deposit)
        {
            var depsited = await _walletService.DepositAsync(deposit);
            if (false == depsited) return BadRequest("Unable to Deposit in this wallet");
            return Ok("Deposit successfully");
        }

        [HttpPost("/transfer")]
        public async Task<ActionResult<string>> Transfer(TransferDto transfer)
        {
            var transferred = await _walletService.TransferAsync(transfer);
            if (false == transferred) return BadRequest("Unable to transfer");
            return Ok("Deposit Successfully");
        }

        [HttpGet("/balance")]
        public async Task<ActionResult<double>> GetBalance(string walletAddress)
        {
            var result = await _walletService.GetBalanceAsync(walletAddress);
            if(result!=null) return Ok(result);
            return BadRequest();
        }
    }
}
