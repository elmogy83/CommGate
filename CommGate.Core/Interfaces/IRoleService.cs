using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommGate.Core.Interfaces
{
    public interface IRoleService
    {
        Task<bool> IsLoggedInUserInAnyRoles(IEnumerable<SystemRoles> applicationRolesToCheck);
    }
}
