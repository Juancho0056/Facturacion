
using MediatR;
using VentasApp.Application.CommandsQueries.Application.Users.Query.GetAll;
using VentasApp.Application.Common.Abstracts;

namespace Application.Application.Users.Query.GetAll
{
    public class GetAllUserRequest : QueryRequest<GetAllUserResponse>
    {
        public string IdentificationCard { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool? IsActive { get; set; }
    }
}
