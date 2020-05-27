using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Tenant.EntityFrameworkCore;

namespace Tenant.Business
{
    public class CreateTenantInput
    {
        [Required]
        [StringLength(TenantPersonnel.MaxInputLength)]
        public virtual string FirstName { get; set; }

        [StringLength(TenantPersonnel.MaxInputLength)]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(TenantPersonnel.MaxInputLength)]
        public virtual string LastName { get; set; }

        [StringLength(TenantPersonnel.MaxInputLength)]
        public virtual string NickName { get; set; }
        public int GenderId { get; set; }

        public virtual DateTime DOB { get; set; }
    }
}
