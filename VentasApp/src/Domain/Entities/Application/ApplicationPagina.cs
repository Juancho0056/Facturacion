using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VentasApp.Domain.Common;

namespace VentasApp.Domain.Entities.Application
{
    [Table("paginas")]
    public class ApplicationPagina : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Titulo { get; set; }
        public string Proyecto { get; set; }
        public string Url { get; set; }
    }
}
