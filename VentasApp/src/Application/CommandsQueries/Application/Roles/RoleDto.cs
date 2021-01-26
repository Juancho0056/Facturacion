using AutoMapper;
using Domain.Entities.Application;
using System.Collections.Generic;
using System.Text;
using VentasApp.Application.Common.Mappings;
using VentasApp.Domain.Common;

namespace Application.Application.Roles
{
    public class RoleDto : AuditableEntity, IMapFrom<ApplicationRole>
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public IEnumerable<MvcControllerInfo> SelectedControllers { get; set; }

        public void Mapping(Profile profile)
        {
            var listControllers = new List<MvcControllerInfo>();
            profile.CreateMap<ApplicationRole, RoleDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(d => d.FechaCreacion, opt => opt.MapFrom(s => s.FechaCreacion))
                .ForMember(d => d.CreadoPor, opt => opt.MapFrom(s => s.CreadoPor))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.NormalizedName, opt => opt.MapFrom(s => s.NormalizedName));
        }
    }
}
