using AutoMapper;
using CommGate.Core.DTOs;
using CommGate.Core.Entities;
using CommGate.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommGate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorrespondenceController : ControllerBase
    {
        private readonly IConfiguration Configuration;
        private IWebHostEnvironment hostingEnvironment;

        private ICorrespondenceService _correspondenceService;
        private readonly IMapper _mapper;
      

        public CorrespondenceController(IMapper mapper, IConfiguration configuration, ICorrespondenceService correspondenceService, IWebHostEnvironment _environment)
        {
            _mapper = mapper;
            Configuration = configuration;
            hostingEnvironment = _environment;
            _correspondenceService = correspondenceService;
           
        }
        [HttpPost("Search")]
        public PagingCollectionResult<CorrespondenceVM> Search(SearchFilters filters)
        {
            var requests = _correspondenceService.SearchInventory(filters);
            var startIndex = (filters.PageIndex - 1) * filters.PageSize;
            var response = new PagingCollectionResult<CorrespondenceVM>
            {
                PageIndex = filters.PageIndex,
                PageSize = filters.PageSize,
                TotalRecords = requests.Count(),
                SortBy = filters.SortBy,
                SortStyle = filters.SortStyle,
                Items = _mapper.Map<IEnumerable<Correspondence>, List<CorrespondenceVM>>(requests.Skip(startIndex).Take(filters.PageSize))
            };

            return response;
        }
    }
}
