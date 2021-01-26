using AutoMapper;
using Domain.Entities;
using VentasApp.Application.Common.Mappings;
using VentasApp.Domain.Common;
using VentasApp.Domain.Enums;

namespace Application.CommandQueries.Marcas
{
    public partial class MarcaDto : AuditableEntity, IMapFrom<Marca>
    {
        public MarcaDto()
        {

        }
        public int Id { get; set; }
        public string Detalle { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Marca, MarcaDto>();
        }
    }
}
