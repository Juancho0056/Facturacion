namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using VentasApp.Domain.Common;

    public partial class Lista : AuditableEntity
    {
        public Lista()
        {
        }
    
        public int Id { get; set; }
        public string Detalle { get; set; }
        public string ModificarPrecioSN { get; set; }
    }
}
