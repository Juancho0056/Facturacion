using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Application
{
    [Table("AspNetUsers")]
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() 
        {
        }
        public string IdentificationCard { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Lastlogin { get; set; }
        public bool EstadoRegistro { get; set; }
        public string CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }


    }
}
