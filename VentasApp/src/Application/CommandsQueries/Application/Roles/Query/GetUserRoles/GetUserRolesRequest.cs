using System.ComponentModel.DataAnnotations;
using VentasApp.Application.Common.Abstracts;

namespace Application.Application.Roles.Query.GetUserRoles
{
    
    public class GetUserRolesRequest : QueryRequest<GetUserRolesResponse>
    {
        [Required]
        public string Username { get; set; }
    }
}
