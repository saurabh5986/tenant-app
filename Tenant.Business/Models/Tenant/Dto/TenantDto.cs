
using System;
using System.Collections.Generic;
using System.Text;
using Tenant.Business;
using Tenant.EntityFrameworkCore;

namespace Tenant.EntityFrameworkCore
{
    public class TenantDto
    {
        public int Id { get; set; }
        public int? TenantId { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string NickName { get; set; }

        public DateTime DOB { get; set; }

        public bool Active { get; set; }

        public int PrefixId { get; set; }

        public Gender GenderFk { get; set; }

    }

}
