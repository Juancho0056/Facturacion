using Application.CommandQueries.Contables;
using System.Collections.Generic;

namespace Application.CommandsQueries.Contables.Queries.GetAll
{
    public class GetAllContableResponse
    {
        public ICollection<ContableDto> Data { get; set; }
        public int Count { get; set; }
        public int Pages { get; set; }
    }
}
