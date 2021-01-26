using Application.CommandQueries.Marcas;
using System.Collections.Generic;

namespace Application.CommandsQueries.Marcas.Queries.GetAll
{
    public class GetAllMarcaResponse
    {
        public ICollection<MarcaDto> Data { get; set; }
        public int Count { get; set; }
        public int Pages { get; set; }
    }
}
