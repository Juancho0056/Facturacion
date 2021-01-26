using Application.CommandQueries.Menus;
using System.ComponentModel.DataAnnotations;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Exceptions;

namespace Application.CommandsQueries.Menus.Queries.Get
{
    public class GetMenuRequest : QueryRequest<MenuDto>
    {
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        public int Id { get; set; }
    }
}
