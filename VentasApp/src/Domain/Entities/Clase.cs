namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using VentasApp.Domain.Common;

    public partial class Clase : AuditableEntity
    {
        public Clase()
        {
        }
    
        public int Id { get; set; }
        public string Detalle { get; set; }
    
    }
}
