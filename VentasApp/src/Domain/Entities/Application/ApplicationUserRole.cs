using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities.Application
{
    [Table("AspNetUserRoles")]
    public class ApplicationUserRole: IdentityUserRole<string>
    {
        public ApplicationUserRole() 
        {
            
        }
        public ApplicationUser User { get; set; }
        public ApplicationRole Role { get; set; }
        public bool EstadoRegistro { get; set; }
        public string CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }

    }
}
