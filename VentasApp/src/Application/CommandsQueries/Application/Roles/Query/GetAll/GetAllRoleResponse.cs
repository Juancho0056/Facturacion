using Application.Application.Roles;
using System;
using System.Collections.Generic;
using System.Text;

namespace VentasApp.Application.CommandsQueries.Application.Roles.Query.GetAll
{
    public class GetAllRoleResponse
    {
        public ICollection<RoleDto> Data { get; set; }
        public int Count { get; set; }
        public int Pages { get; set; }
    }
}