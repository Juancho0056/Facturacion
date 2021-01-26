using Application.CommandQueries.Clases;
using System.ComponentModel.DataAnnotations;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Exceptions;

namespace Application.CommandsQueries.Clases.Queries.Get
{
    public class GetClaseRequest : QueryRequest<ClaseDto>
    {
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        public int Id { get; set; }
    }
}
