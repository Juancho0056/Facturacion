namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using VentasApp.Domain.Common;

    public partial class ImpoConsumo : AuditableEntity
    {
        public ImpoConsumo()
        {
        }
    
        public int Id { get; set; }
        public string Detalle { get; set; }
        public decimal Valor { get; set; }
    }
}
