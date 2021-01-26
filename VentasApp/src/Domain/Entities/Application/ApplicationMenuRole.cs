using Domain.Entities.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VentasApp.Domain.Common;

namespace VentasApp.Domain.Entities.Application
{
    [Table("menusroles")]
    public class ApplicationMenuRole : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public string RoleId { get; set; }
        public virtual ApplicationRole Role { get; set; }
        public int MenuId { get; set; }
        public virtual ApplicationMenu Menu { get; set; }
        

    }
}
