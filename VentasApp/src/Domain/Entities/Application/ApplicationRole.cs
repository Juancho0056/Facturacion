using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities.Application
{
    [Table("AspNetRoles")]
    public class ApplicationRole: IdentityRole
    {
        public ApplicationRole() : base() 
        {
        }
        public ApplicationRole(string name) : base(name) { }
        public string Description { get; set; }
        public string Access { get; set; }
        public bool EstadoRegistro { get; set; }
        public string CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
