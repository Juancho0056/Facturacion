namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using VentasApp.Domain.Common;

    public partial class MedioPago : AuditableEntity
    {
        public string Id { get; set; }
        public string Detalle { get; set; }
    }
}
