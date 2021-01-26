using Application.CommandQueries.Clases;
using System.Collections.Generic;

namespace Application.CommandsQueries.Clases.Queries.GetAll
{
    public class GetAllClaseResponse
    {
        public ICollection<ClaseDto> Data { get; set; }
        public int Count { get; set; }
        public int Pages { get; set; }
    }
}
