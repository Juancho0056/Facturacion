using System;
using System.Collections.Generic;
using System.Text;

namespace VentasApp.Application.Common.Models
{
    public class AuditableEntityDto
    {
        public bool EstadoRegistro { get; set; }
        public string CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
