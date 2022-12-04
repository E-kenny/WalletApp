using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WalletApp.Abstractions.Services;

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
        public ActionResult<string> GetId()
        {
            
            var id = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var id = _walletService.GetId();
            return Ok(id!=null?id:"Nothing here");
        }
    }
}
