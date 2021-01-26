using AutoMapper;
using Domain.Entities;
using VentasApp.Application.Common.Mappings;
using VentasApp.Domain.Common;
using VentasApp.Domain.Enums;

namespace Application.CommandQueries.Contables
{
    public partial class ContableDto : AuditableEntity, IMapFrom<Contable>
    {
        public ContableDto()
        {

        }
        public int Id { get; set; }
        public string Detalle { get; set; }
        public int IvaVentaId { get; set; }
        public int IvaCompraId { get; set; }
        public int ImpoConsumoId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Contable, ContableDto>();
        }
    }
}
