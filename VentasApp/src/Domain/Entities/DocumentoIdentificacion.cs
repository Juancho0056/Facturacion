namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using VentasApp.Domain.Common;

    public partial class DocumentoIdentificacion : AuditableEntity
    {
        public DocumentoIdentificacion()
        {
        }

        public int Id { get; set; }
        public string Sigla { get; set; }
        public string Detalle { get; set; }
    }
}