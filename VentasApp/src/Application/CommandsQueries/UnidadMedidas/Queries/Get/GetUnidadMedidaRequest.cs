using Application.CommandQueries.UnidadMedidas;
using System.ComponentModel.DataAnnotations;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Exceptions;

namespace Application.CommandsQueries.UnidadMedidas.Queries.Get
{
    public class GetUnidadMedidaRequest : QueryRequest<UnidadMedidaDto>
    {
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        public string Id { get; set; }
    }
}
