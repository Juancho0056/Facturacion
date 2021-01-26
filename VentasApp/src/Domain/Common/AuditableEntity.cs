using System;
using System.ComponentModel.DataAnnotations;

namespace VentasApp.Domain.Common
{
    public abstract class AuditableEntity
    {
        public bool EstadoRegistro { get; set; }
        [MaxLength(60)]
        public string CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        [MaxLength(60)]
        public string ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
