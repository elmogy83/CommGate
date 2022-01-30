using CommGate.Core;
using CommGate.Core.Entities;
using CommGate.Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommGate.Service
{
    public class RoleService : IRoleService
    {
        private readonly IRepositoryBase<ApplicationRole> _applicationRoleRepository;
        private readonly IRepositoryBase<ApplicationUser> _applicationUserRepository;
        private readonly IUserAccountService _userAccountService;
        private readonly UserManager<ApplicationUser> _userManager;
       

        public RoleService(IRepositoryBase<ApplicationRole> applicationRoleRepository,
            UserManager<ApplicationUser> userManager,
            IUserAccountService userAccountService,
            IRepositoryBase<ApplicationUser> applicationUserRepository)
        {
            _applicationRoleRepository = applicationRoleRepository;
            _userAccountService = userAccountService;
            _userManager = userManager;            
            _applicationUserRepository = applicationUserRepository;


        }

        public async Task<bool> IsLoggedInUserInAnyRoles(IEnumerable<SystemRoles> applicationRolesToCheck)
        {
            var loggedInUser = await _userAccountService.GetLoggedInUser();

            var isUserInSuperAdminRole = await IsUserSuperAdministrator(loggedInUser);
            if (isUserInSuperAdminRole)
                return true;

            var userRoles = await _userManager.GetRolesAsync(loggedInUser);
            var isRoleExist = applicationRolesToCheck.Any(c => userRoles.Any(r => string.Equals(r, c.ToString(), StringComparison.InvariantCultureIgnoreCase)));
            if (isRoleExist)
                return true;

            return false;
        }

        #region Private Methods

        public async Task<bool> IsUserSuperAdministrator(ApplicationUser user)
        {
            var adminRoleName = Enum.GetName(typeof(SystemRoles), SystemRoles.Admin);
            var isUserInAdminRole = await _userManager.IsInRoleAsync(user, adminRoleName);
            return isUserInAdminRole;
        }

        #endregion
    }
}
