using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WalletApp.Abstractions.Services;

namespace WalletApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        public WalletController(IWalletService walletService)
        {

        }
    }
}
