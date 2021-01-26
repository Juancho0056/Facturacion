
using System.ComponentModel.DataAnnotations;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Exceptions;
using VentasApp.Domain.Enums;

namespace Application.CommandsQueries.Marcas.Queries.GetAll
{
    public class GetAllMarcaRequest : QueryRequest<GetAllMarcaResponse>
    {
        public int Id { get; set; }
        public string Detalle { get; set; }
        public bool? EstadoRegistro { get; set; }
    }
}
