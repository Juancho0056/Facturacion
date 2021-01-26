using Application.CommandQueries.Grupos;
using System.Collections.Generic;

namespace Application.CommandsQueries.Grupos.Queries.GetAll
{
    public class GetAllGrupoResponse
    {
        public ICollection<GrupoDto> Data { get; set; }
        public int Count { get; set; }
        public int Pages { get; set; }
    }
}
