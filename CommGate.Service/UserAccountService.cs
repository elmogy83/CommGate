using CommGate.Core.DTOs;
using CommGate.Core.Entities;
using CommGate.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleIdentity.Services
{
    public class UserAccountService : IUserAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ConfigurationsManager _configurationsManager;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public UserAccountService(IHttpContextAccessor httpContextAccessor,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ConfigurationsManager configurationsManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _signInManager = signInManager;
            _configurationsManager = configurationsManager;
        }

        public async Task<ApplicationUser> AuthorizeUser(AutheticationBindingVM autheticationBindingModel)
        {
            var user = await _userManager.FindByNameAsync(autheticationBindingModel.UserName);
            if (user == null)
                throw new Exception("InvalidLogin");

            var signInResult = await _signInManager.CheckPasswordSignInAsync(user,
                autheticationBindingModel.Password, user.LockoutEnabled);
            if (signInResult.Succeeded == false)
                throw new Exception("InvalidLogin");

            return user;
        }

        public async Task<ApplicationUser> FindNormalUserByUserName(string userName)
        {
            var applicationUser = await _userManager.FindByNameAsync(userName);
            if (applicationUser != null)
                return applicationUser;

            return null;
        }
    }
}
