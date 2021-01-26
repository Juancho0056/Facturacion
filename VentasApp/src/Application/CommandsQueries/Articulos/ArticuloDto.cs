using AutoMapper;
using Domain.Entities;
using VentasApp.Application.Common.Mappings;
using VentasApp.Application.Common.Models;

namespace Application.CommandQueries.Articulos
{
    public partial class ArticuloDto : AuditableEntityDto, IMapFrom<Articulo>
    {
        public ArticuloDto()
        {

        }
        public int Id { get; set; }
        public string Detalle { get; set; }
        public string Descripcion { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Articulo, ArticuloDto>();
        }
    }
}
