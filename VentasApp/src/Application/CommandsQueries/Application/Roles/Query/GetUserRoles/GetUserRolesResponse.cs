using Application.Application.Roles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Application.Roles.Query.GetUserRoles
{
    public class GetUserRolesResponse
    {
        public ICollection<RoleDto> Data { get; set; }
        public int Count { get; set; }
        public int Pages { get; set; }
    }
}