namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using VentasApp.Domain.Common;

    public partial class TipoDocumento : AuditableEntity
    {
        public TipoDocumento()
        {
        }
    
        public int Id { get; set; }
        public string Detalle { get; set; }
        public string Identificador { get; set; }
    
    }
}
