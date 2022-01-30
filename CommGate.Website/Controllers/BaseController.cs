using CommGate.Core.DTOs;
using CommGate.Website.Extensions;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CommGate.Website.Controllers
{

    [BreadcrumbActionFilter]   
    public class BaseController : Controller
    {
        protected readonly IConfiguration _baseconfiguration;
        public BaseController(IConfiguration baseconfiguration)
        {
            _baseconfiguration = baseconfiguration;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);


        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);

            string userName = "user one";

            //HttpContext.Session.SetString("DisplayName", userName);

            //ViewBag.UserName = HttpContext.Session.GetString("DisplayName");
            //ViewBag.CurrentCulture = HttpContext.Session.GetString("culture");
            ViewBag.HostAddress = Request.Scheme + "://" + Request.Host;
            ViewBag.Scheme = Request.Scheme;
            //ViewBag.IsAuthenticated = User.Identity.IsAuthenticated;
            if (HttpContext.Request.Cookies["commgatetoken"] != null)
            {
                TokenVM token = Newtonsoft.Json.JsonConvert.DeserializeObject<TokenVM>(HttpContext.Request.Cookies["commgatetoken"]);

                ViewBag.Claims = string.Join(",", token.roles);
            }
           // ViewBag.UserId = User.Identity.Name;
        }
        public bool IsEnglish => HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.UICulture.Name == "en-US";
    }
}
