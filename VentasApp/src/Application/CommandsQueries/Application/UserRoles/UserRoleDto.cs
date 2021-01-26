

using AutoMapper;
using Domain.Entities.Application;
using VentasApp.Application.Common.Mappings;
using VentasApp.Domain.Common;

namespace Application.Application.UserRoles
{
    public class UserRoleDto : AuditableEntity, IMapFrom<ApplicationUserRole>
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public ApplicationUser User { get; set; }
        public ApplicationRole Role { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ApplicationUserRole, UserRoleDto>()
                .ForMember(d => d.UserId, opt => opt.MapFrom(s => s.UserId))
                .ForMember(d => d.RoleId, opt => opt.MapFrom(s => s.RoleId))
                .ForMember(d => d.Role, opt => opt.MapFrom(s => s.Role))
                .ForMember(d => d.User, opt => opt.MapFrom(s => s.User))
                ;
        }
    }
}
