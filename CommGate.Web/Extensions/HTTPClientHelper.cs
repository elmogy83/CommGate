using CommGate.Core;
using CommGate.Core.DTOs;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace CommGate.Web.Extensions
{
    public class HTTPClientHelper
    {
        private readonly IConfiguration _configuration;

        public HTTPClientHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public static HttpClient GetHttpClientWithoutAuth(ClaimsPrincipal User)
        {


            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            HttpClient MyHttpClient = new HttpClient(handler);
            MyHttpClient.BaseAddress = new Uri(AppConfiguration.GetAppSettingString("SiteSettings", "BaseUrl"));
            MyHttpClient.DefaultRequestHeaders
     .Accept
     .Add(new MediaTypeWithQualityHeaderValue("application/json"));



            //MyHttpClient.DefaultRequestHeaders.Add("User", JsonConvert.SerializeObject(new ApiToken()
            //{
            //    UserName = User.Identity.Name,
            //    IsAuthenticated = User.Identity.IsAuthenticated,
            //    Claims = User.Claims.Select(s => s.Value).ToList()
            //}));
            return MyHttpClient;
        }

    }
}
