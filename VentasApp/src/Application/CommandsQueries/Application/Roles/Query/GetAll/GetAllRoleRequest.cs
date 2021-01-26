
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using VentasApp.Application.Common.Abstracts;

namespace VentasApp.Application.CommandsQueries.Application.Roles.Query.GetAll
{
    public class GetAllRoleRequest :  QueryRequest<GetAllRoleResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
    }
}
