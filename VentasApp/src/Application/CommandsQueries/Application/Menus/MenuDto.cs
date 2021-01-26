using Application.CommandQueries.Paginas;
using AutoMapper;
using Domain.Entities;
using System;
using VentasApp.Application.Common.Mappings;
using VentasApp.Domain.Common;
using VentasApp.Domain.Entities.Application;
using VentasApp.Domain.Enums;

namespace Application.CommandQueries.Menus
{
    public partial class MenuDto : AuditableEntity, IMapFrom<ApplicationMenu>
    {
        public MenuDto()
        {

        }
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Nombre { get; set; }
        public string Url { get; set; }
        public Nullable<int> Padre { get; set; }
        public Nullable<int> PaginaId { get; set; }
        public PaginaDto Pagina { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ApplicationMenu, MenuDto>()
                .ForMember(x=> x.Pagina, opt => opt.MapFrom(s => s.Pagina));
        }
    }
}
