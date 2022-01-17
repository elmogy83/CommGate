using CommGate.Core.DTOs;


namespace CommGate.WebAPI.Providers.Interfaces
{
    public interface IOAuthAuthorizationProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="loginBindingModel"></param>
        /// <returns></returns>
        Task<object> GrantCredentials(HttpRequest request, LoginBindingVM loginBindingModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        Task<object> GrantRefreshToken(HttpRequest request, string refreshToken = null);
    }
}
