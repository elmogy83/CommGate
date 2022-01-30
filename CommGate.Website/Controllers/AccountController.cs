using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.Data;
using System.Collections;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using CommGate.Core.Entities;
using CommGate.Website.Controllers;
using Microsoft.Extensions.Localization;
using CommGate.Core.DTOs;
using CommGate.Website.Extensions;
using System.Text;

namespace Ashghal.SafetyQuestionnaires.Web.Controllers
{

    public class AccountController : BaseController
    {
        private IStringLocalizer stringLocalizer;
        private readonly IConfiguration Configuration;
        public AccountController(IConfiguration configuration, IStringLocalizer<CorrespondenceController> _stringLocalizer)
            : base(configuration)
        {
            stringLocalizer = _stringLocalizer;
            Configuration = configuration;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            LoginVM model = new LoginVM();
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            LoginBindingVM loginBindingVM = new LoginBindingVM();
            loginBindingVM.UserName = model.Email;
            loginBindingVM.Password = model.Password;
            object userToken;
            var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(loginBindingVM), Encoding.UTF8, "application/json");
            using (var httpClient = HTTPClientHelper.GetHttpClientWithoutAuth())
            {
                var url = string.Format("api/Account/token");
                HttpResponseMessage response = httpClient.PostAsync(url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    userToken = response.Content.ReadAsStringAsync().Result;
                    HttpContext.Response.Cookies.Append("commgatetoken", userToken.ToString());
                    return Redirect("/Home/Index");
                }
                
            }
            //var result = await _signManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);


            //if (result.Succeeded)
            //{
            //    var user = await getUser(model.Email);

            //    if (user.Deactivate.HasValue && user.Deactivate.Value)
            //    {
            //        ModelState.AddModelError("FailureText", "User is dective, please contact the administrator.");
            //        return View(model);
            //    }

            //    HttpContext.Session.SetString("UserID", user.UserName);

            //    if (user.LastLoginDate == null)
            //    {

            //        if (user.Deactivate == true)
            //        {
            //            ModelState.AddModelError("CustomError", "Invalid login attempt");
            //        }

            //        return RedirectToAction(nameof(FirstLoginReset), "Account", new { EmailId = model.Email, key = 1 });
            //    }
            //    else
            //    {

            //        return RedirectToAction("Default", "Pages");
            //    }
            //}
            //else if (result.IsLockedOut)
            //{
            //    return RedirectToAction("AdminResetPassword", "Account", new { EmailId = model.Email, key = 1 });
            //}

            //else
            //    ModelState.AddModelError("FailureText", "Invalid user name or password.");




            return View(model);

        }
      

        //[HttpPost]
        //public async Task<IActionResult> Logout()
        //{
        //    await _signManager.SignOutAsync();
        //    return RedirectToAction("Login", "Account");
        //}
        //private Task<ApplicationUser> getUser(string Email)
        //{
        //    return IdentityHelper.GetUser(Email);
        //}
        //public ActionResult AllUsers()
        //{
        //    var roles = _identityService.getAllRoles();
        //    roles.Insert(0, new ApplicationRole { Id = 0, Name = "All" });
        //    ViewBag.roleList = roles;




        //    AllUserVM objAllUserVM = new AllUserVM();
        //    List<ApplicationUser> objAllUser = new List<ApplicationUser>();
        //    objAllUser = LoadUsers(0);
        //    objAllUserVM.UserList = objAllUser;
        //    return View(objAllUserVM);
        //}
        //public ActionResult RegisterUser()
        //{
        //    RegisterUserModel objRegisterViewModel = new RegisterUserModel();
        //    RoleList objRoleList;
        //    objRegisterViewModel.roleLists = new List<RoleList>();


        //    foreach (var item in loadRoles())
        //    {
        //        objRoleList = new RoleList();
        //        objRoleList.RoleId = item.Id;
        //        objRoleList.RoleName = item.Name;
        //        objRegisterViewModel.roleLists.Add(objRoleList);
        //    }
        //    objRegisterViewModel.UserTypes = new List<UserTypeVM>();
        //    return View(objRegisterViewModel);
        //}

        //[HttpPost]
        //public async Task<IActionResult> RegisterUser(RegisterUserModel objRegisterViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var isEmailAlreadyExists = _identityService.getUserByEmail(objRegisterViewModel.Email);
        //        if (isEmailAlreadyExists)
        //        {
        //            ModelState.AddModelError("Email", "Email is already exists");
        //            return View(objRegisterViewModel);
        //        }
        //        var user = new ApplicationUser()
        //        {
        //            UserName = objRegisterViewModel.Email,
        //            Email = objRegisterViewModel.Email,
        //            DisplayName = objRegisterViewModel.DisplayName,
        //            PhoneNumber = objRegisterViewModel.PhoneNumber,
        //            CompanyName = objRegisterViewModel.CompanyName,
        //            EmailConfirmed = true,

        //        };

        //        IdentityResult result = await _identityService.CreateUser(user, objRegisterViewModel.Password);
        //        if (result.Succeeded)
        //        {
        //            //  Add user to role

        //            foreach (var item in objRegisterViewModel.roleLists)
        //            {
        //                if (item.IsSelected)
        //                {
        //                    await _identityService.AddUserRole(_identityService.GetRoleByID(item.RoleId).Result, user);

        //                }
        //            }
        //            _mail = new Mail(_identityService, _hostingEnvironment, _userManager, _httpContextAccessor);
        //            _mail.SendRegistrationMail(user.Id, objRegisterViewModel.Password);
        //        }
        //    }
        //    else
        //    {
        //        //ModelState.AddModelError("CustomError", result.Errors.FirstOrDefault().Description.ToString());
        //        return View(objRegisterViewModel);
        //    }
        //    return RedirectToAction("AllUsers");
        //}
        //private IEnumerable<ApplicationRole> loadRoles()
        //{
        //    return IdentityHelper.GetAllRoles(_roleManager).Result.Where(r => !r.Name.Contains("Consultant"));
        //}
        //[HttpPost]
        //public async Task<IActionResult> RegisterConsultant(RegisterConsultantModel objRegisterConsultantViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var isEmailAlreadyExists = _identityService.getUserByEmail(objRegisterConsultantViewModel.Email);
        //        if (isEmailAlreadyExists)
        //        {
        //            ModelState.AddModelError("Email", "Email is already exists");

        //            objRegisterConsultantViewModel = LoadRegistrationLookups(objRegisterConsultantViewModel);
        //            return View(objRegisterConsultantViewModel);
        //        }

        //        var user = new ApplicationUser()
        //        {
        //            UserName = objRegisterConsultantViewModel.Email,
        //            Email = objRegisterConsultantViewModel.Email,
        //            DisplayName = objRegisterConsultantViewModel.DisplayName,
        //            PhoneNumber = objRegisterConsultantViewModel.PhoneNumber,
        //            UserType = objRegisterConsultantViewModel.UserTypeId,
        //            FirmID = objRegisterConsultantViewModel.FirmId,
        //            //CompanyName = _projectsService.GetFirmByID(objRegisterConsultantViewModel.FirmId).Name,
        //            EmailConfirmed = true,
        //        };
        //        IdentityResult result = await _identityService.CreateUser(user, objRegisterConsultantViewModel.Password);
        //        if (result.Succeeded)
        //        {
        //            await _userManager.AddToRoleAsync(user, "Consultant");

        //            _mail = new Mail(_identityService, _hostingEnvironment, _userManager);
        //            _mail.SendRegistrationMail(user.Id, objRegisterConsultantViewModel.Password);
        //        }
        //    }
        //    else
        //    {

        //        objRegisterConsultantViewModel = LoadRegistrationLookups(objRegisterConsultantViewModel);

        //        return View(objRegisterConsultantViewModel);
        //    }
        //    return RedirectToAction("AllUsers");
        //}
        //[HttpGet]
        //[AllowAnonymous]
        //public IActionResult RegisterConsultant()
        //{
        //    RegisterConsultantModel model = new RegisterConsultantModel();

        //    model = LoadRegistrationLookups(model);

        //    return View(model);
        //}
        //private RegisterConsultantModel LoadRegistrationLookups(RegisterConsultantModel model)
        //{
        //    model.firms = _mapper.Map<List<ConsultancyFirmVM>>(_projectsService.GetAllConsultancyFirm());
        //    var userTypes = Enum.GetValues(typeof(UserTypes))
        //                .Cast<UserTypes>()
        //                .Select(d => (d, (int)d))
        //                .ToList();
        //    List<UserTypeVM> userTypeVMs = new List<UserTypeVM>();

        //    foreach (var item in userTypes)
        //    {
        //        UserTypeVM userType = new UserTypeVM();
        //        userType.key = item.Item2;
        //        userType.value = item.Item1.ToString();
        //        userTypeVMs.Add(userType);

        //    }
        //    model.UserTypes = userTypeVMs;
        //    return model;
        //}
        //private List<ApplicationUser> LoadUsers(int RoleId)
        //{
        //    List<ApplicationUser> source = new List<ApplicationUser>();

        //    if (RoleId == 0)
        //    {
        //        source = _identityService.GetAllUsers().ToList();
        //    }
        //    else if (RoleId != 0)
        //    {
        //        source = _identityService.FindUsersInRole(2).Where(u => u.UserType == (int)UserTypes.ProjectEngineer).ToList();
        //    }
        //    else
        //    {
        //        source = _identityService.FindUsersInRole(RoleId).ToList();
        //    }

        //    foreach (var item in source)
        //    {
        //        if (item.FirmID.HasValue && item.FirmID != 0)
        //        {
        //            item.CompanyName = _projectsService.GetFirmByID(item.FirmID.Value).Name;

        //        }
        //    }
        //    return source;
        //}
        //[HttpGet]
        //[AllowAnonymous]
        //public IActionResult ForgetPassword()
        //{
        //    return View();
        //}
        //[HttpPost]
        //[AllowAnonymous]
        //public async Task<IActionResult> ForgetPassword(string Email)
        //{
        //    ApplicationUser user = await _userManager.FindByNameAsync(Email);
        //    if (user == null || !await _userManager.IsEmailConfirmedAsync(user))
        //    {
        //        ModelState.AddModelError("CustomError", "The user either does not exist or is not confirmed.");
        //        return View();
        //    }
        //    _mail.SendAccountResetLink(user);
        //    ViewBag.MailSent = true;
        //    return View();
        //}
        //[HttpGet]
        //[AllowAnonymous]
        //public IActionResult AdminResetPassword([FromQuery(Name = "EmailId")] string Email, [FromQuery(Name = "code")] int key)
        //{
        //    try
        //    {
        //        ResetPasswordViewModel vm = new ResetPasswordViewModel();
        //        var userData = _adminHelper.GetConsultantData(Email);
        //        vm.Email = userData.Email;

        //        return View("AdminResetPassword", vm);
        //    }
        //    catch (Exception e)
        //    {

        //        return RedirectToAction("popupError", "Home", new { errorMsg = e.Message });
        //    }
        //}
        //[HttpPost]
        //[AllowAnonymous]
        //public async Task<IActionResult> AdminResetPassword(RegisterUserModel objRegisterViewModel)
        //{
        //    try
        //    {
        //        var result = await _adminHelper.ResetPassword(objRegisterViewModel);
        //        if (result.Succeeded)
        //        {
        //            if (objRegisterViewModel.key == 1)
        //            {
        //                return RedirectToAction("Login", "Account");
        //            }

        //        }

        //        return Json(new { success = true, message = "Saved Successfully" });

        //    }
        //    catch (Exception e)
        //    {

        //        return RedirectToAction("popupError", "Home", new { errorMsg = e.Message });
        //    }

        //}

        //[HttpGet]
        //public async Task<IActionResult> FirstLoginReset([FromQuery(Name = "EmailId")] string Email)
        //{
        //    ResetPasswordViewModel vm = null;
        //    try
        //    {
        //        vm = new ResetPasswordViewModel();
        //        var userData = _adminHelper.GetConsultantData(Email);
        //        vm.Email = userData.Email;

        //    }
        //    catch (Exception e)
        //    {


        //    }
        //    return View("FirstLoginReset", vm);
        //}

        //[HttpPost]
        //public async Task<IActionResult> FirstLoginReset(RegisterUserModel objRegisterViewModel)
        //{
        //    try
        //    {
        //        var result = await _adminHelper.ResetPassword(objRegisterViewModel);
        //        if (result.Succeeded)
        //        {
        //            if (objRegisterViewModel.key == 1)
        //            {
        //                return RedirectToAction("Login", "Account");
        //            }

        //        }

        //    }
        //    catch (Exception e)
        //    {

        //        // Handle Exception
        //    }
        //    return RedirectToAction("Default", "Pages");

        //}

        //[HttpGet]
        //public async Task<IActionResult> BlockUnblockUser([FromQuery(Name = "UserId")] string UserId, [FromQuery(Name = "CommandName")] string CommandName)
        //{
        //    int CurrentUserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
        //    var result = await _adminHelper.BlockUnblockUser(UserId, CommandName, CurrentUserId);
        //    return RedirectToAction("AllUsers", "Account");


        //}




       

        //[HttpGet]
        //public IActionResult UpdateConsultantProfile([FromQuery(Name = "Email")] string Email)
        //{
        //    RegisterConsultantModel userData = new RegisterConsultantModel();
        //    userData = _adminHelper.GetConsultentData(Email);

        //    if (userData.FirmId != 0)
        //        userData.ConsultancyFirm = _projectsService.GetFirmByID(userData.FirmId).Name;
        //    return View(userData);
        //}
        //[HttpPost]
        //public async Task<IActionResult> UpdateConsultantProfile(RegisterConsultantModel objRegisterConsultantViewModel)
        //{
        //    var userModel = _mapper.Map<RegisterUserModel>(objRegisterConsultantViewModel);
        //    await _adminHelper.UpdateProfile(userModel, true);
        //    return RedirectToAction("AllUsers", "Account");
        //}




        //[HttpGet]
        //public IActionResult UpdateProfile([FromQuery(Name = "EmailId")] string Email)
        //{
        //    RegisterUserModel userData = new RegisterUserModel();
        //    userData = _adminHelper.GetUserData(Email);
        //    return View(userData);
        //}
        //[HttpPost]

        //public async Task<IActionResult> UpdateProfile(RegisterUserModel objRegisterViewModel)
        //{
        //    await _adminHelper.UpdateProfile(objRegisterViewModel, false);
        //    return RedirectToAction("AllUsers", "Account");
        //}



    }


}
