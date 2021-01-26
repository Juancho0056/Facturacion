namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using VentasApp.Domain.Common;

    public partial class ReteFuente : AuditableEntity
    {
        public ReteFuente()
        {
        }
    
        public int Id { get; set; }
        public string Detalle { get; set; }
        public decimal Porcentaje { get; set; }
        public string CuentaV { get; set; }
        public string CuentaDV { get; set; }
        public string CuentaC { get; set; }
        public string CuentaDC { get; set; }
        public string TipoCatalogo { get; set; }
        public string DeclaranteSN { get; set; }
        public int Ano { get; set; }
        public decimal Tope { get; set; }
    }
}
