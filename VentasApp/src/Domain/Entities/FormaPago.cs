namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using VentasApp.Domain.Common;

    public partial class FormaPago : AuditableEntity
    {
        public string Id { get; set; }
        public string Detalle { get; set; }
        public string MedioPago { get; set; }
    }
}
