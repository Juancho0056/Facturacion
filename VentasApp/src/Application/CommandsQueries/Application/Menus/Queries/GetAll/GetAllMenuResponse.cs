using Application.CommandQueries.Menus;
using System.Collections.Generic;

namespace Application.CommandsQueries.Menus.Queries.GetAll
{
    public class GetAllMenuResponse
    {
        public ICollection<MenuDto> Data { get; set; }
        public int Count { get; set; }
        public int Pages { get; set; }
    }
}
