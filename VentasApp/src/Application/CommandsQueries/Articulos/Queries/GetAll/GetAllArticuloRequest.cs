
using MediatR;
using System.ComponentModel.DataAnnotations;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Exceptions;
using VentasApp.Domain.Enums;

namespace Application.CommandsQueries.Articulos.Queries.GetAll
{
    public class GetAllArticuloRequest : QueryRequest<GetAllArticuloResponse>
    {
        public string Detalle { get; set; }
        public string Descripcion { get; set; }
        public string Modelo { get; set; }
        public string Referencia { get; set; }
        public string Imagen { get; set; }
        public string Observacion { get; set; }
        [EnumDataType(typeof(TipoCatalogo), ErrorMessage = ErrorMessage.IsEnum)]
        public TipoCatalogo TipoCatalogo { get; set; }
        public int ClaseId { get; set; }
        public int ContableId { get; set; }
        public int GrupoId { get; set; }
        public int MarcaId { get; set; }
        public string UnidadMedidaId { get; set; }
        public bool? EstadoRegistro { get; set; }
    }
}
