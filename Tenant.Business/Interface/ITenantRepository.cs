using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tenant.EntityFrameworkCore;

namespace Tenant.Business
{
   public interface ITenantRepository
    {
        Task<List<TenantDto>> GetAll();

        Task<TenantDto> GetById(int id);

        Task<bool> Create(CreateTenantInput input);

        Task<bool> Update(UpdateTenantInput input);

        Task<bool> Delete(int id);
    }
}
