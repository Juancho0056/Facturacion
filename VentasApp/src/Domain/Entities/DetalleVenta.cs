namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using VentasApp.Domain.Common;

    public partial class DetalleVenta : AuditableEntity
    {
        public int Id { get; set; }
        public int VentaId { get; set; }
        public int ArticuloId { get; set; }
        public string Detalle { get; set; }
        public string UnidadId { get; set; }
        public decimal Descuento { get; set; }
        public decimal Cantidad { get; set; }
        public int IvaId { get; set; }
        public decimal PorcentajeIva { get; set; }
        public decimal ValorUnitario { get; set; }
        public int ListaPrecioId { get; set; }
        public decimal ValorLista { get; set; }
        public int ReteFuenteId { get; set; }
        public decimal PorcentajeRtfte { get; set; }
        public decimal VlrRtfteC { get; set; }
        public decimal VlrRtfteS { get; set; }
        public int ReteIcaId { get; set; }
        public decimal PorcentajeReteIca { get; set; }
        public decimal VlrRteIcaC { get; set; }
        public decimal VlrRteIcaS { get; set; }
        public decimal VlrDescuento { get; set; }
        public decimal VentaBruta { get; set; }
        public decimal VlrIva { get; set; }
        public decimal DescComercial { get; set; }
        public int ImpoConsumoId { get; set; }
        public decimal PorImpoConsumo { get; set; }
        public decimal VlrImpoConsumo { get; set; }
    
        public virtual Articulo Articulo { get; set; }
        public virtual ImpoConsumo ImpoConsumo { get; set; }
        public virtual Iva Iva { get; set; }
        public virtual ListaPrecio ListaPrecio { get; set; }
        public virtual ReteFuente ReteFuente { get; set; }
        public virtual ReteIca ReteIca { get; set; }
        public virtual UnidadMedida UnidadMedida { get; set; }
        public virtual Venta Venta { get; set; }
    }
}
