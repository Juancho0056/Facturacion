using AutoMapper;
using Domain.Entities;
using VentasApp.Application.Common.Mappings;
using VentasApp.Domain.Common;
using VentasApp.Domain.Enums;

namespace Application.CommandQueries.Grupos
{
    public partial class GrupoDto : AuditableEntity, IMapFrom<Grupo>
    {
        public GrupoDto()
        {

        }
        public int Id { get; set; }
        public string Detalle { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Grupo, GrupoDto>();
        }
    }
}
