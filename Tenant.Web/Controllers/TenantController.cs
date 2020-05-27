using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Tenant.Business;
using Tenant.Business.Models;
using Tenant.EntityFrameworkCore;
using Tenant.Web.Models;

namespace Tenant.Web.Controllers
{
    public class TenantController : Controller
    {
        private const string WebApiBaseUrl = "http://localhost:64753/api/";
        private const string TenantCreateEndPoint = "tenant/create";
        private const string TenantUpdateEndPoint = "tenant/update";
        private const string TenantDeleteEndPoint = "tenant/delete";
        private const string TenantGetAllEndPoint = "tenant/getall";
        private const string TenantGetByIdEndPoint = "tenant/getbyid";
        private const string GenderGetAllEndPoint = "gender/getall";




        public async Task<ActionResult> Index()
        {
            try
            {
                var requestUri = $"{WebApiBaseUrl}{TenantGetAllEndPoint}";
                HttpResponseMessage httpResponseMessage = await HttpRequestFactory.Get(requestUri);

                var response = httpResponseMessage.ContentAsType<ApiResponse>();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var output = JsonConvert.DeserializeObject<List<TenantDto>>(response.Data.ToString());
                    var model = new TenantIndexViewModel(output);
                    return View(model);
                }
                return null;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ActionResult> Create()
        {
            try
            {
                var genderSelectListItems = await GetGenderItemList();

                genderSelectListItems.Insert(0, new SelectListItem { Value = string.Empty, Text = "Not Specified", Selected = true });

                return View(new TenantViewModel { Gender = genderSelectListItems });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TenantViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var requestUri = $"{WebApiBaseUrl}{TenantCreateEndPoint}";
                    HttpResponseMessage httpResponseMessage = await HttpRequestFactory.Post(requestUri, model);

                    var response = httpResponseMessage.ContentAsType<ApiResponse>();

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        return RedirectToAction("Index", "Tenant");
                    }
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ActionResult> Update(int id)
        {
            try
            {

                if (id > 0)
                {
                    var requestUri = $"{WebApiBaseUrl}{TenantGetByIdEndPoint}/{id}";
                    HttpResponseMessage httpResponseMessage = await HttpRequestFactory.Get(requestUri);

                    var response = httpResponseMessage.ContentAsType<ApiResponse>();
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var output = JsonConvert.DeserializeObject<TenantDto>(response.Data.ToString());
                        var genderSelectListItems = await GetGenderItemList();
                        genderSelectListItems.Insert(0, new SelectListItem { Value = string.Empty, Text = "Not Specified" });
                        foreach (var item in genderSelectListItems)
                        {
                            if (item.Value == output.GenderFk.Id.ToString())
                                item.Selected = true;
                        }
                        var tenant = new TenantViewModel
                        {
                            FirstName = output.FirstName,
                            LastName = output.LastName,
                            DOB = output.DOB,
                            MiddleName = output.MiddleName,
                            Gender = genderSelectListItems,
                            Id = output.Id,
                            NickName = output.NickName,
                            GenderId = output.GenderFk.Id
                        };

                        return View(tenant);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(TenantViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var requestUri = $"{WebApiBaseUrl}{TenantUpdateEndPoint}";
                    HttpResponseMessage httpResponseMessage = await HttpRequestFactory.Put(requestUri, model);

                    var response = httpResponseMessage.ContentAsType<ApiResponse>();

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        return RedirectToAction("Index", "Tenant");
                    }
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var requestUri = $"{WebApiBaseUrl}{TenantDeleteEndPoint}/{id}";
                    HttpResponseMessage httpResponseMessage = await HttpRequestFactory.Delete(requestUri);

                    var response = httpResponseMessage.ContentAsType<ApiResponse>();

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        return RedirectToAction("Index", "Tenant");
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<SelectListItem>> GetGenderItemList()
        {
            try
            {
                var requestUri = $"{WebApiBaseUrl}{GenderGetAllEndPoint}";
                HttpResponseMessage httpResponseMessage = await HttpRequestFactory.Get(requestUri);

                var response = httpResponseMessage.ContentAsType<ApiResponse>();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var output = JsonConvert.DeserializeObject<List<Gender>>(response.Data.ToString());
                    return output.Select(p => new SelectListItem(p.Name, p.Id.ToString()))
                       .ToList();
                }
                return null;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}