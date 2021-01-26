
using Application.Application.Roles;
using AutoMapper;
using Domain.Entities.Application;
using System;
using System.Collections.Generic;
using VentasApp.Application.Common.Mappings;

namespace Application.Application.Users.Command.Login
{
    public  class LoginUserDto: IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime LastLogin { get; set; }
        public string Token { get; set; }
        public DateTime ExpirationToken { get; set; }
        public ICollection<RoleDto> Roles { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ApplicationUser, LoginUserDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Username, opt => opt.MapFrom(s => s.UserName))
                .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.FirstName))
                .ForMember(d => d.LastName, opt => opt.MapFrom(s => s.LastName))
                .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Email))
                .ForMember(d => d.LastLogin, opt => opt.MapFrom(s => s.Lastlogin));
            ;
        }
    }
}
