using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tenant.EntityFrameworkCore;

namespace Tenant.Web.Models
{
    public class TenantIndexViewModel
    {
        public IReadOnlyList<TenantDto> Tenants { get; }

        public TenantIndexViewModel(IReadOnlyList<TenantDto> tenants)
        {
            Tenants = tenants;
        }

        public string GetTaskLabel(TenantDto task)
        {
            switch (task.Active)
            {
                case true:
                    return "label-success";
                default:
                    return "label-default";
            }
        }
    }
}
