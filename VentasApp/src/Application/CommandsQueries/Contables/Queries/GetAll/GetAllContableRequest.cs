
using System.ComponentModel.DataAnnotations;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Exceptions;
using VentasApp.Domain.Enums;

namespace Application.CommandsQueries.Contables.Queries.GetAll
{
    public class GetAllContableRequest : QueryRequest<GetAllContableResponse>
    {
        public int Id { get; set; }
        public string Detalle { get; set; }
        public int IvaVentaId { get; set; }
        public int IvaCompraId { get; set; }
        public int ImpoConsumoId { get; set; }
        public bool? EstadoRegistro { get; set; }
    }
}
