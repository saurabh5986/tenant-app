using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tenant.Business;

namespace Tenant.API.Controllers
{
    [Route("api/gender")]
    [ApiController]
    public class GenderApiController : ControllerBase
    {
        private readonly IGenderRepository _genderAppService;

        public GenderApiController(IGenderRepository genderAppService)
        {
            _genderAppService = genderAppService;
        }

        [HttpGet("getall")]
        public async Task<ApiResponse> GetAllGenders()
        {
            try
            {
                var tenantList = await _genderAppService.GetAll();
                return new ApiResponse(HttpStatusCode.OK, tenantList);
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, null, ex.InnerException.ToString());
            }
        }
    }
}