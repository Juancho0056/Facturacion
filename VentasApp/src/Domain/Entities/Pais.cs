namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using VentasApp.Domain.Common;

    public partial class Pais : AuditableEntity
    {
        public Pais()
        {
        }
    
        public int Id { get; set; }
        public string Detalle { get; set; }
    }
}
