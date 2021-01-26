using Application.CommandQueries.UnidadMedidas;
using System.Collections.Generic;

namespace Application.CommandsQueries.UnidadMedidas.Queries.GetAll
{
    public class GetAllUnidadMedidaResponse
    {
        public ICollection<UnidadMedidaDto> Data { get; set; }
        public int Count { get; set; }
        public int Pages { get; set; }
    }
}
