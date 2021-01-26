namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using VentasApp.Domain.Common;

    public partial class Articulo: AuditableEntity
    {
        public Articulo()
        {

        }
    
        public int Id { get; set; }
        public string Detalle { get; set; }
        public string Descripcion { get; set; }
        public decimal Factor { get; set; }
        public string Modelo { get; set; }
        public string Referencia { get; set; }
        public string Imagen { get; set; }
        public string Observacion { get; set; }
        public string TipoCatalogo { get; set; }
        public int ClaseId { get; set; }
        public int ContableId { get; set; }
        public int GrupoId { get; set; }
        public int MarcaId { get; set; }
        public string UnidadMedidaId { get; set; }
    
        public virtual Clase Clase { get; set; }
        public virtual Contable Contable { get; set; }
        public virtual Grupo Grupo { get; set; }
        public virtual Marca Marca { get; set; }
        public virtual UnidadMedida UnidadMedida { get; set; }
    }
}
