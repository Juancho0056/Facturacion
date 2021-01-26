
using System.ComponentModel.DataAnnotations;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Exceptions;
using VentasApp.Domain.Enums;

namespace Application.CommandsQueries.Paginas.Queries.GetAll
{
    public class GetAllPaginaRequest : QueryRequest<GetAllPaginaResponse>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Titulo { get; set; }
        public string Proyecto { get; set; }
        public string Url { get; set; }
        public bool? EstadoRegistro { get; set; }
    }
}
