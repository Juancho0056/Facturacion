namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using VentasApp.Domain.Common;

    public partial class UnidadMedida : AuditableEntity
    {
        public UnidadMedida()
        {
        }
    
        public string Id { get; set; }
        public string Detalle { get; set; }
    }
}
