namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using VentasApp.Domain.Common;

    public partial class Cliente : AuditableEntity
    {
        public Cliente()
        {
        }
    
        public int Id { get; set; }
        public decimal DescuentoComercial { get; set; }
        public string ReteIcaSN { get; set; }
        public string ReteIvaSN { get; set; }
        public string ReteFteSN { get; set; }
        public string AutoRetenedorSN { get; set; }
        public string DeclaranteSN { get; set; }
        public string Estado { get; set; }
        public decimal Cupo { get; set; }
        public int TipoCompradorId { get; set; }
        public int ZonaId { get; set; }
        public int RepresentanteVentas { get; set; }
        public int ListaPrecioId { get; set; }
        public int ReteFuenteServiciosId { get; set; }
        public int ReteFuenteId { get; set; }
        public int ReteIcaServiciosId { get; set; }
        public int ReteIcaId { get; set; }
    
        public virtual ReteFuente ReteFuente { get; set; }
        public virtual ReteFuente ReteFuenteServicios { get; set; }
        public virtual ReteIca ReteIca { get; set; }
        public virtual ReteIca ReteIcaServicios { get; set; }
        public virtual Lista ListaPrecio { get; set; }
        public virtual RepVenta RepVenta { get; set; }
        public virtual TipoComprador TipoComprador { get; set; }
        public virtual Zona Zona { get; set; }
    }
}
