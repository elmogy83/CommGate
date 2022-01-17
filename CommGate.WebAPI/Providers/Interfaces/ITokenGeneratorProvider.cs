using CommGate.Core.Entities;

namespace CommGate.WebAPI.Providers.Interfaces
{
    public interface ITokenGeneratorProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="clientId"></param>
        /// <returns></returns>
        Task<object> GenerateUserToken(ApplicationUser user, string clientId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="refreshTokenKey"></param>
        /// <param name="clientId"></param>
        /// <returns></returns>
        Task<object> GenerateUserTokenByRefreshToken(string refreshTokenKey, string clientId);
    }
}
