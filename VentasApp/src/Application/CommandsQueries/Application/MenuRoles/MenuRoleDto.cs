

using AutoMapper;
using Domain.Entities.Application;
using VentasApp.Application.Common.Mappings;
using VentasApp.Domain.Common;
using VentasApp.Domain.Entities.Application;

namespace Application.Application.MenuRoles
{
    public class MenuRoleDto : AuditableEntity, IMapFrom<ApplicationMenuRole>
    {


        public void Mapping(Profile profile)
        {
            profile.CreateMap<ApplicationMenuRole, MenuRoleDto>()
                ;
        }
    }
}
