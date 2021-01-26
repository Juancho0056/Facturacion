
using System.ComponentModel.DataAnnotations;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Exceptions;
using VentasApp.Domain.Enums;

namespace Application.CommandsQueries.UnidadMedidas.Queries.GetAll
{
    public class GetAllUnidadMedidaRequest : QueryRequest<GetAllUnidadMedidaResponse>
    {
        public int Id { get; set; }
        public string Detalle { get; set; }
        public bool? EstadoRegistro { get; set; }
    }
}
