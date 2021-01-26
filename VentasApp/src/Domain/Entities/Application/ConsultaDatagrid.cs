using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VentasApp.Domain.Common;

namespace VentasApp.Domain.Entities.Application
{
    [Table("ConsultaDatagrid")]
    public class ConsultaDatagrid: AuditableEntity
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Pagina { get; set; }
        public string SentenciaCount { get; set; }
        public string SentenciaTable { get; set; }
    }
}
