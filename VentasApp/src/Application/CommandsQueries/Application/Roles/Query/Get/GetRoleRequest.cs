using Application.Application.Roles;
using System.ComponentModel.DataAnnotations;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Exceptions;

namespace Application.Application.Menus.Query.Get
{
    public class GetRoleRequest : QueryRequest<RoleDto>
    {
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        public string Id { get; set; }
    }
}
