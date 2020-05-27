using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tenant.EntityFrameworkCore;

namespace Tenant.Business
{
    public interface IGenderRepository
    {
        Task<List<Gender>> GetAll();
    }
}
