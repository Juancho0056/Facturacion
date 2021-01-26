using AutoMapper;
using Domain.Entities;
using VentasApp.Application.Common.Mappings;
using VentasApp.Domain.Common;
using VentasApp.Domain.Entities.Application;
using VentasApp.Domain.Enums;

namespace Application.CommandQueries.Paginas
{
    public partial class PaginaDto : AuditableEntity, IMapFrom<ApplicationPagina>
    {
        public PaginaDto()
        {

        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Titulo { get; set; }
        public string Proyecto { get; set; }
        public string Url { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ApplicationPagina, PaginaDto>()
                .ForMember(x => x.CreadoPor, opt => opt.MapFrom(s => s.CreadoPor))
                .ForMember(x => x.FechaCreacion, opt => opt.MapFrom(s => s.FechaCreacion))
                .ForMember(x => x.ModificadoPor, opt => opt.MapFrom(s => s.ModificadoPor))
                .ForMember(x => x.FechaModificacion, opt => opt.MapFrom(s => s.FechaModificacion))
                .ForMember(x => x.EstadoRegistro, opt => opt.MapFrom(s => s.EstadoRegistro))
                ;
        }
    }
}
