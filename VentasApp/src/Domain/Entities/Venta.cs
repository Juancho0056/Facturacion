namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using VentasApp.Domain.Common;

    public partial class Venta : AuditableEntity
    {
        public Venta()
        {
        }
    
        public int Id { get; set; }
        public string NroFactura { get; set; }
        public int TipoDocumentoId { get; set; }
        public DateTime FechaVenta { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int ClienteId { get; set; }
        public string MunicipioId { get; set; }
        public int RepVentaId { get; set; }
        public Nullable<int> CajaId { get; set; }
        public string Observacion { get; set; }
        public decimal TotalBruto { get; set; }
        public decimal DsctoProd { get; set; }
        public decimal DsctoComer { get; set; }
        public decimal BaseIva { get; set; }
        public decimal ValorIva { get; set; }
        public decimal ValorVenta { get; set; }
        public decimal TotalRetefuenteC { get; set; }
        public decimal TotalRetefuenteS { get; set; }
        public decimal TotalReteIcaC { get; set; }
        public decimal TotalReteIcaS { get; set; }
        public decimal TotalReteIva { get; set; }
        public decimal TotalOtrRetencion { get; set; }
        public decimal TotalAutoRetencion { get; set; }
        public decimal TotalPagar { get; set; }
        public string Resolucion { get; set; }
        public decimal ValorImpConsumo { get; set; }
    
        public virtual Caja Caja { get; set; }
        public virtual Ciudad Ciudad { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual RepVenta RepVenta { get; set; }
        public virtual TipoDocumento TipoDocumento { get; set; }
    }
}
