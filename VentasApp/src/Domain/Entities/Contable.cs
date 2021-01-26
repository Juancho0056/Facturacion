namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using VentasApp.Domain.Common;

    public partial class Contable : AuditableEntity
    {
        public Contable()
        {
        }
    
        public int Id { get; set; }
        public string Detalle { get; set; }
        public int IvaVentaId { get; set; }
        public int IvaCompraId { get; set; }
        public int ImpoConsumoId { get; set; }
    
        public virtual ImpoConsumo ImpoConsumo { get; set; }
        public virtual Iva IvaVenta { get; set; }
        public virtual Iva IvaCompra { get; set; }
    }
}
