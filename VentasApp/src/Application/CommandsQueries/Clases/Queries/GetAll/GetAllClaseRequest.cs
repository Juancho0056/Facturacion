
using System.ComponentModel.DataAnnotations;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Exceptions;
using VentasApp.Domain.Enums;

namespace Application.CommandsQueries.Clases.Queries.GetAll
{
    public class GetAllClaseRequest : QueryRequest<GetAllClaseResponse>
    {
        public int Id { get; set; }
        public string Detalle { get; set; }
        public bool? EstadoRegistro { get; set; }
    }
}
