using Application.CommandQueries.Contables;
using System.ComponentModel.DataAnnotations;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Exceptions;

namespace Application.CommandsQueries.Contables.Queries.Get
{
    public class GetContableRequest : QueryRequest<ContableDto>
    {
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        public int Id { get; set; }
    }
}
