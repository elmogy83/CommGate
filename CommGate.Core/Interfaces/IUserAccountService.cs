using CommGate.Core.DTOs;
using CommGate.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommGate.Core.Interfaces
{
    public interface IUserAccountService
    {
        Task<ApplicationUser> AuthorizeUser(AutheticationBindingVM autheticationBindingModel);
        Task<ApplicationUser> FindNormalUserByUserName(string userName);
    }
}
