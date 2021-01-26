using Application.CommandQueries.Paginas;
using System.Collections.Generic;

namespace Application.CommandsQueries.Paginas.Queries.GetAll
{
    public class GetAllPaginaResponse
    {
        public ICollection<PaginaDto> Data { get; set; }
        public int Count { get; set; }
        public int Pages { get; set; }
        public int Total { get; set; }
    }
}
