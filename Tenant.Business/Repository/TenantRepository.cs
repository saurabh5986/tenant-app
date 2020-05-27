
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tenant.EntityFrameworkCore;

namespace Tenant.Business
{
    public class TenantRepository : ITenantRepository
    {
        readonly TenantDbContext _dbContext;

        public TenantRepository(TenantDbContext context)
        {
            _dbContext = context;
        }
        public async Task<bool> Create(CreateTenantInput input)
        {
            try
            {
                await _dbContext.TenantPersonnels.AddAsync(new TenantPersonnel
                {
                    FirstName = input.FirstName,
                    LastName = input.LastName,
                    MiddleName = input.MiddleName,
                    DOB = input.DOB,
                    NickName = input.NickName,
                    Active = true,
                    GenderFk = await _dbContext.Genders.FirstOrDefaultAsync(s => s.Id == input.GenderId)
                });
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var tenant = await _dbContext.TenantPersonnels.FirstOrDefaultAsync(s => s.Id == id);
                _dbContext.TenantPersonnels.Remove(tenant);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<TenantDto>> GetAll()
        {
            try
            {
                var tenants = await _dbContext.TenantPersonnels.Include(s => s.GenderFk).ToListAsync();

                return tenants.Select(s => new TenantDto
                {
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    MiddleName = s.MiddleName,
                    Active = s.Active,
                    DOB = s.DOB,
                    GenderFk = s.GenderFk,
                    PrefixId = s.PrefixId,
                    NickName = s.NickName,
                    TenantId = s.TenantId,
                    Id = s.Id
                }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TenantDto> GetById(int id)
        {
            try
            {
                if (id > 0)
                {
                    var tenantObj = await _dbContext.TenantPersonnels.Where(s => s.Id == id).Include(s => s.GenderFk).FirstOrDefaultAsync();
                    var tenant = new TenantDto
                    {
                        FirstName = tenantObj.FirstName,
                        LastName = tenantObj.LastName,
                        MiddleName = tenantObj.MiddleName,
                        Active = tenantObj.Active,
                        DOB = tenantObj.DOB,
                        GenderFk = tenantObj.GenderFk,
                        PrefixId = tenantObj.PrefixId,
                        NickName = tenantObj.NickName,
                        TenantId = tenantObj.TenantId
                    };
                    return tenant;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Update(UpdateTenantInput input)
        {
            try
            {
                if (input != null && input.Id > 0)
                {
                    var tenant = await _dbContext.TenantPersonnels.FirstOrDefaultAsync(s => s.Id == input.Id);

                    tenant.FirstName = input.FirstName;
                    tenant.LastName = input.LastName;
                    tenant.MiddleName = input.MiddleName;
                    tenant.NickName = input.NickName;
                    tenant.DOB = input.DOB;
                    tenant.PrefixId = input.PrefixId;
                    tenant.TenantId = input.TenantId;
                    tenant.GenderFk = await _dbContext.Genders.FirstOrDefaultAsync(s => s.Id == input.GenderId);

                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
