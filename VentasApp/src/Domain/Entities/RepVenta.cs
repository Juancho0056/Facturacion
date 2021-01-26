namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using VentasApp.Domain.Common;

    public partial class RepVenta : AuditableEntity
    {
        public RepVenta()
        {
        }
    
        public int Id { get; set; }
        public decimal MetaVenta { get; set; }
        public decimal Comision { get; set; }
        public string Notas { get; set; }
        public int TerceroId { get; set; }
        public virtual Tercero Tercero { get; set; }
    }
}
