using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Tenant.EntityFrameworkCore
{
    [Table("TenantPersonnel")]
    public class TenantPersonnel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public const int MaxInputLength = 50;
        public int? TenantId { get; set; }

        [Required]
        [StringLength(MaxInputLength)]
        public virtual string FirstName { get; set; }

        [StringLength(MaxInputLength)]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(MaxInputLength)]
        public virtual string LastName { get; set; }

        [StringLength(MaxInputLength)]
        public virtual string NickName { get; set; }

        public virtual DateTime DOB { get; set; }

        public virtual bool Active { get; set; }

        public virtual int PrefixId { get; set; }

        [ForeignKey("GenderId")]
        public Gender GenderFk { get; set; }

    }

}
