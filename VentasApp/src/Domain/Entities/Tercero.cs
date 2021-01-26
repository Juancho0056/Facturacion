namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using VentasApp.Domain.Common;

    public partial class Tercero : AuditableEntity
    {
        public Tercero()
        {
        }
    
        public int Id { get; set; }
        public string NroDocumento { get; set; }
        public string DigitoVerificacion { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string RazonSocial { get; set; }
        public string NombreComercial { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Telefono { get; set; }
        public Nullable<System.DateTime> FechaNacimiento { get; set; }
        public int DocumentoId { get; set; }
        public int RegimenId { get; set; }
        public int TipoPersonaId { get; set; }
        public string CiudadUbicacion { get; set; }
    
        public virtual Ciudad Ciudad { get; set; }
        public virtual DocumentoIdentificacion DocumentoIdentificacion { get; set; }
        public virtual Regimen Regimen { get; set; }
        public virtual TipoPersona TipoPersona { get; set; }
    }
}
