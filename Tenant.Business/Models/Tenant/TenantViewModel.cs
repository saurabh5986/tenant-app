using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Tenant.EntityFrameworkCore;

namespace Tenant.Business.Models
{
    public class TenantViewModel
    {
        public int Id { get; set; }
        public List<SelectListItem> Gender { get; set; }
        public int GenderId { get; set; }
        [Required]
        [Display(Name = "First Name")]
        [StringLength(TenantPersonnel.MaxInputLength)]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]

        [StringLength(TenantPersonnel.MaxInputLength)]
        public string MiddleName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [StringLength(TenantPersonnel.MaxInputLength)]
        public string LastName { get; set; }

        [Display(Name = "Niick Name")]

        [StringLength(TenantPersonnel.MaxInputLength)]
        public string NickName { get; set; }

        [Display(Name = "Date Of Birth")]
        public DateTime DOB { get; set; }

    }
}
