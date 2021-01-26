namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using VentasApp.Domain.Common;

    public partial class Consecutivo : AuditableEntity
    {
        public int Id { get; set; }
        public string NroResolucion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Detalle { get; set; }
        public int Longitud { get; set; }
        public int NumeroInicio { get; set; }
        public int NumeroFin { get; set; }
        public string Prefijo { get; set; }
        public string Descripcion { get; set; }
        public int NroActual { get; set; }
        public int TipoDocumentoId { get; set; }
    
        public virtual TipoDocumento TipoDocumento { get; set; }
    }
}
