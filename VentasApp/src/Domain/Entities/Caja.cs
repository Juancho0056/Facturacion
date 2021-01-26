namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using VentasApp.Domain.Common;

    public partial class Caja : AuditableEntity
    {
        public Caja()
        {
        }
    
        public int Id { get; set; }
        public string Detalle { get; set; }
    }
}
