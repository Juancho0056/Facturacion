using AutoMapper;
using Domain.Entities;
using VentasApp.Application.Common.Mappings;
using VentasApp.Domain.Common;
using VentasApp.Domain.Enums;

namespace Application.CommandQueries.UnidadMedidas
{
    public partial class UnidadMedidaDto : AuditableEntity, IMapFrom<UnidadMedida>
    {
        public UnidadMedidaDto()
        {

        }
        public int Id { get; set; }
        public string Detalle { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UnidadMedida, UnidadMedidaDto>();
        }
    }
}
