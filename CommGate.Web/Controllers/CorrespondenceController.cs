using CommGate.Core.DTOs;
using CommGate.Web.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Text;

namespace CommGate.Web.Controllers
{
    public class CorrespondenceController : BaseController
    {
        private IStringLocalizer stringLocalizer;
        private readonly IConfiguration Configuration;

        public CorrespondenceController(IConfiguration configuration, IStringLocalizer<CorrespondenceController> _stringLocalizer)
            : base(configuration)
        {
            stringLocalizer = _stringLocalizer;
            Configuration = configuration;
        }
        // GET: CorrespondenceController
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Search(SearchFilters filters)
        {
            if (filters.PageIndex <= 0) filters.PageIndex = 1;
            if (filters.PageSize <= 0) filters.PageSize = Convert.ToInt32(Configuration["SiteSettings:DefaultPageSize"]);
            PagingCollectionResult<CorrespondenceVM> allCorrespondenceItems = null;
            var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(filters), Encoding.UTF8, "application/json");

            using (var httpClient = HTTPClientHelper.GetHttpClientWithoutAuth(User))
            {
                var url = string.Format("Api/Correspondence/Search");
                HttpResponseMessage response = httpClient.PostAsync(url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    allCorrespondenceItems = Newtonsoft.Json.JsonConvert.DeserializeObject<PagingCollectionResult<CorrespondenceVM>>(response.Content.ReadAsStringAsync().Result);
                }
            }

            return PartialView("Correspondence", allCorrespondenceItems);
        }
    }
}
