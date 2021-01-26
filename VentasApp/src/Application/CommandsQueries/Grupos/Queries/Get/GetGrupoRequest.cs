using Application.CommandQueries.Grupos;
using System.ComponentModel.DataAnnotations;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Exceptions;

namespace Application.CommandsQueries.Grupos.Queries.Get
{
    public class GetGrupoRequest : QueryRequest<GrupoDto>
    {
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        public int Id { get; set; }
    }
}
