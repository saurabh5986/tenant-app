using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tenant.Business;
using Tenant.Business.Models;

namespace Tenant.API.Controllers
{
    [Route("api/tenant")]
    [ApiController]
    public class TenantApiController : ControllerBase
    {
        private readonly ITenantRepository _tenantAppService;

        public TenantApiController(ITenantRepository tenantAppService)
        {
            _tenantAppService = tenantAppService;
        }

        [HttpGet("getall")]
        public async Task<ApiResponse> GetAllTenants()
        {
            try
            {
                var tenantList = await _tenantAppService.GetAll();
                return new ApiResponse(HttpStatusCode.OK, tenantList);
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, null, ex.InnerException.ToString());
            }
        }

        [HttpGet("getbyid/{Id}")]
        public async Task<ApiResponse> GetTenantById(int Id)
        {
            try
            {
                var tenant = await _tenantAppService.GetById(Id);
                return new ApiResponse(HttpStatusCode.OK, tenant);
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, null, ex.InnerException.ToString());

            }
        }

        [HttpPost("create")]
        public async Task<ApiResponse> CreateTenant([FromBody]TenantViewModel createTenant)
        {
            try
            {
                await _tenantAppService.Create(new CreateTenantInput
                {
                    FirstName = createTenant.FirstName,
                    LastName = createTenant.LastName,
                    MiddleName = createTenant.MiddleName,
                    DOB = Convert.ToDateTime(createTenant.DOB),
                    NickName = createTenant.NickName,
                    GenderId = createTenant.GenderId
                });
                return new ApiResponse(HttpStatusCode.OK, null, "Tenant created successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, null, ex.InnerException.ToString());
            }
        }

        [HttpPut("update")]
        public async Task<ApiResponse> UpdateTenant(TenantViewModel updateTenant)
        {
            try
            {
                await _tenantAppService.Update(new UpdateTenantInput
                {
                    FirstName = updateTenant.FirstName,
                    LastName = updateTenant.LastName,
                    MiddleName = updateTenant.MiddleName,
                    DOB = Convert.ToDateTime(updateTenant.DOB),
                    NickName = updateTenant.NickName,
                    Id = updateTenant.Id,
                    GenderId = updateTenant.GenderId
                });
                return new ApiResponse(HttpStatusCode.OK, null, "Tenant updated successfully.");
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, null, ex.InnerException.ToString());
            }
        }

        [HttpDelete("delete/{Id}")]
        public async Task<ApiResponse> DeleteTenant(int Id)
        {
            try
            {
                var tenant = await _tenantAppService.Delete(Id);
                return new ApiResponse(HttpStatusCode.OK, tenant);
            }
            catch (Exception ex)
            {
                return new ApiResponse(HttpStatusCode.BadRequest, null, ex.InnerException.ToString());

            }
        }
    }
}