

using AutoMapper;
using Domain.Entities.Application;
using VentasApp.Application.Common.Mappings;
using VentasApp.Domain.Common;

namespace Application.Application.Users
{
    public class UserDto : AuditableEntity, IMapFrom<ApplicationUser>
    {
        public string IdentificationCard { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ApplicationUser, UserDto>();
        }
    }
}
