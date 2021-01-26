using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VentasApp.Domain.Common;

namespace VentasApp.Domain.Entities.Application
{
    [Table("menus")]
    public class ApplicationMenu : AuditableEntity
    {
        public ApplicationMenu()
        {
        }

        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Nombre { get; set; }
        public string Url { get; set; }
        public Nullable<int> Padre { get; set; }
        public Nullable<int> PaginaId { get; set; }
        public virtual ApplicationPagina Pagina { get; set; }


    }
}
