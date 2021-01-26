namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using VentasApp.Domain.Common;

    public partial class Ciudad : AuditableEntity
    {
        public Ciudad()
        {
        }
    
        public string Id { get; set; }
        public int DepartamentoId { get; set; }
        public string Detalle { get; set; }
        public virtual Departamento Departamento { get; set; }
    }
}
