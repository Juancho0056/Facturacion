using Application.CommandQueries.Permisos;
using System.Collections.Generic;

namespace Application.CommandsQueries.Permisos.Queries.GetAll
{
    public class GetAllPermisoResponse
    {
        public ICollection<PermisoDto> Data { get; set; }
        public int Count { get; set; }
        public int Pages { get; set; }
    }
}
