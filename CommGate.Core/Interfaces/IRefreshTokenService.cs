using CommGate.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommGate.Core.Interfaces
{
    public interface IRefreshTokenService
    {
        Task<string> GenerateRefreshTokenAsync(string username, string clientId);

        Task<RefreshTokenVM> GetRefreshTokenByProtectedTicketAsync(string protectedTicket);

        Task DeleteRefreshTokenByProtectedKeyAsync(string refreshToken);
    }
}
