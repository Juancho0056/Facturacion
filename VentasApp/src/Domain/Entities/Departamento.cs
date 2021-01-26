namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using VentasApp.Domain.Common;

    public partial class Departamento : AuditableEntity
    {
        public Departamento()
        {
        }
    
        public int Id { get; set; }
        public string Detalle { get; set; }
        public int PaisId { get; set; }
        public virtual Pais Pais { get; set; }
    }
}
