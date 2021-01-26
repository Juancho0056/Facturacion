using VentasApp.Application.Common.Abstracts;

namespace Application.CommandsQueries.Permisos.Queries.GetAll
{
    public class GetAllPermisoRequest : QueryRequest<GetAllPermisoResponse>
    {
        public int Id { get; set; }
        public string Detalle { get; set; }
        public string Slug { get; set; }
        public int MenuRoleId { get; set; }
        public bool? EstadoRegistro { get; set; }
    }
}
