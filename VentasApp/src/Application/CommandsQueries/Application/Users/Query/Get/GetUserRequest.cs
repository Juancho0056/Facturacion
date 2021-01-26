using Application.Application.Users;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VentasApp.Application.Common.Abstracts;

namespace Application.Application.Menus.Query.Get
{
    public class GetUserRequest : QueryRequest<UserDto>
    {
        [Required]
        public string Id { get; set; }
    }
}
