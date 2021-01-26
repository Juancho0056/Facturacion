namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using VentasApp.Domain.Common;

    public partial class Iva : AuditableEntity
    {
        public Iva()
        {
        }
    
        public int Id { get; set; }
        public string Detalle { get; set; }
        public decimal Valor { get; set; }
    }
}
