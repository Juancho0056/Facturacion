using Application.CommandQueries.Articulos;
using System.ComponentModel.DataAnnotations;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Exceptions;

namespace Application.CommandsQueries.Articulos.Queries.Get
{
    public class GetArticuloRequest : QueryRequest<ArticuloDto>
    {
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        public int Id { get; set; }
    }
}
