namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using VentasApp.Domain.Common;

    public partial class ListaPrecio : AuditableEntity
    {
        public ListaPrecio()
        {
        }
    
        public int Id { get; set; }
        public Nullable<decimal> Precio { get; set; }
        public int ListaId { get; set; }
        public int ArticuloId { get; set; }
        public string UnidadMedidaId { get; set; }
    
        public virtual Articulo Articulo { get; set; }
        public virtual Lista Lista { get; set; }
        public virtual UnidadMedida UnidadMedida { get; set; }
    }
}
