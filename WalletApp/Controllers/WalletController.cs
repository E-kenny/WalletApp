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
            return Ok(await _walletService.CreateWalletAsync());
        }

        [HttpPost]
        public async Task<ActionResult<string>> Deposit(DepositDto deposit)
        {
            var depsited = await _walletService.DepositAsync(deposit);
            if (false == depsited) return BadRequest("Unable to Deposit in this wallet");
            return Ok("Deposit successfully");
        }
    }
}
