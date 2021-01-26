using Application.CommandQueries.Articulos;
using System.Collections.Generic;

namespace Application.CommandsQueries.Articulos.Queries.GetAll
{
    public class GetAllArticuloResponse
    {
        public ICollection<ArticuloDto> Data { get; set; }
        public int Count { get; set; }
        public int Pages { get; set; }
    }
}
