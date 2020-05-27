using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tenant.EntityFrameworkCore;

namespace Tenant.Business
{
    public class GenderRepository : IGenderRepository
    {
        readonly TenantDbContext _dbContext;

        public GenderRepository(TenantDbContext context)
        {
            _dbContext = context;
        }
        public async Task<List<Gender>> GetAll()
        {
            try
            {
                return await _dbContext.Genders.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
