
using System.ComponentModel.DataAnnotations;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Exceptions;
using VentasApp.Domain.Enums;

namespace Application.CommandsQueries.Grupos.Queries.GetAll
{
    public class GetAllGrupoRequest : QueryRequest<GetAllGrupoResponse>
    {
        public int Id { get; set; }
        public string Detalle { get; set; }
        public bool? EstadoRegistro { get; set; }
    }
}
