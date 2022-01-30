using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CommGate.WebAPI.Filters;
using CommGate.WebAPI.Providers.Interfaces;
using System.Net;
using CommGate.Core.Interfaces;
using CommGate.Core.DTOs;

namespace CommGate.WebAPI.Controllers.Account
{
    /// <summary>
	/// 
	/// </summary>
	[Route("api/Account")]
    [Produces("application/json")]
    [ApiController]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public class AccountController : ControllerBase
    {
        private readonly IUserAccountService _accountService;
        private readonly IOAuthAuthorizationProvider _oAuthAuthorizationProvider;
        private readonly IConfiguration _configuration ;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountService"></param>
        /// <param name="oAuthAuthorizationProvider"></param>
        /// <param name="configuration"></param>
        public AccountController(IUserAccountService accountService,
            IOAuthAuthorizationProvider oAuthAuthorizationProvider,
            IConfiguration configuration)
        {
            _accountService = accountService;
            _oAuthAuthorizationProvider = oAuthAuthorizationProvider;
            _configuration = configuration;
        }

        /// <summary>
        /// Authenticate the user by (username and password) and generate a JWT token for this user.
        /// </summary>
        /// <param name="loginBindingModel"></param>
        /// <returns></returns>
        [HttpPost("token")]
        [AllowAnonymous]
        [ApiExplorerSettings(IgnoreApi = true)]
        //[ServiceFilter(typeof(ClientAuthenticationFilterAttribute))]
        public async Task<IActionResult> Token(LoginBindingVM loginBindingModel)
        {
            try
            {
                var userToken = await _oAuthAuthorizationProvider.GrantCredentials(Request, loginBindingModel);
                return Ok(userToken);
            }
            catch (Exception ex)
            {
                switch (ex.Message)
                {
                    case "InvalidLogin":
                        return Unauthorized();
                        break;
                    default:
                        return NotFound();
                        break;
                }
             
            }
            
        }

        /// <summary>
        /// Get a new JWT token by using refresh token.
        /// </summary>
        /// <param name="refresh_token"></param>
        /// <returns></returns>
        [HttpPost("refreshtoken")]
        [AllowAnonymous]
        [ApiExplorerSettings(IgnoreApi = true)]
        [ServiceFilter(typeof(ClientAuthenticationFilterAttribute))]
        //[RestrictedIPFilter(isRestrictedLogin: true)]
        public async Task<IActionResult> RefreshToken(string refresh_token)
        {
            var userToken = await _oAuthAuthorizationProvider.GrantRefreshToken(Request, refresh_token);
            return Ok(userToken);
        }
       
    }
}


