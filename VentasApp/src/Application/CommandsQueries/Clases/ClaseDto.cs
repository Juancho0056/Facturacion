using AutoMapper;
using Domain.Entities;
using VentasApp.Application.Common.Mappings;
using VentasApp.Domain.Common;
using VentasApp.Domain.Enums;

namespace Application.CommandQueries.Clases
{
    public partial class ClaseDto : AuditableEntity, IMapFrom<Clase>
    {
        public ClaseDto()
        {

        }
        public int Id { get; set; }
        public string Detalle { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Clase, ClaseDto>();
        }
    }
}
