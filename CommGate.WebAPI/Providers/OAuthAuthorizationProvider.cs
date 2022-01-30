using Microsoft.AspNetCore.Identity;
using CommGate.WebAPI.Filters;
using CommGate.WebAPI.Providers.Interfaces;
using CommGate.Core.Entities;
using CommGate.Core.DTOs;
using CommGate.Core.Interfaces;

namespace CommGate.WebAPI.Providers
{
    public class OAuthAuthorizationProvider : IOAuthAuthorizationProvider
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ConfigurationsManager _configuration;
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly IClientService _clientService;
        private readonly IUserAccountService _accountService;
        private readonly ITokenGeneratorProvider _tokenGeneratorProvider;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="configuration"></param>
        /// <param name="refreshTokenService"></param>
        /// <param name="clientService"></param>
        /// <param name="accountService"></param>
        /// <param name="tokenGeneratorProvider"></param>
        public OAuthAuthorizationProvider(
          UserManager<ApplicationUser> userManager,
          ConfigurationsManager configuration,
          IRefreshTokenService refreshTokenService,
          IClientService clientService,
          IUserAccountService accountService,
          ITokenGeneratorProvider tokenGeneratorProvider)
        {
            _userManager = userManager;
            _configuration = configuration;
            _refreshTokenService = refreshTokenService;
            _clientService = clientService;
            _accountService = accountService;
            _tokenGeneratorProvider = tokenGeneratorProvider;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="loginBindingModel"></param>

        /// <returns></returns>
        public async Task<object> GrantCredentials(HttpRequest request, LoginBindingVM loginBindingModel)
        {
           // var clientId = HttpRequestHeaderHelper.GetClientIdFromHeader(request);
            var authorizeRequest = new AutheticationBindingVM(loginBindingModel.UserName,
                loginBindingModel.Password,
                "SystemClient");

            var loggedInUser = await _accountService.AuthorizeUser(authorizeRequest);

            var userToken = await _tokenGeneratorProvider.GenerateUserToken(loggedInUser, "SystemClient");
            return userToken;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        public async Task<object> GrantRefreshToken(HttpRequest request, string refreshToken)
        {
            var clientId = HttpRequestHeaderHelper.GetClientIdFromHeader(request);
            return await _tokenGeneratorProvider.GenerateUserTokenByRefreshToken(refreshToken, clientId);
        }
    }
}
