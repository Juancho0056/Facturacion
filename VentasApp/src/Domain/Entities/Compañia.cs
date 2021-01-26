namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using VentasApp.Domain.Common;

    public partial class Compañia : AuditableEntity
    {
        public int Id { get; set; }
        public bool Autorretenedor { get; set; }
        public int TerceroId { get; set; }
    
        public virtual Tercero Tercero { get; set; }
    }
}
