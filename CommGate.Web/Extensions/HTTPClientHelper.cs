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



            // MyHttpClient.DefaultRequestHeaders.Add("Authorization", $"bearer {ff}");
            return MyHttpClient;
        }

    }
}
