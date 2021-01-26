using AutoMapper;
using Domain.Entities;
using VentasApp.Application.Common.Mappings;
using VentasApp.Domain.Common;
using VentasApp.Domain.Entities.Application;
using VentasApp.Domain.Enums;

namespace Application.CommandQueries.Permisos
{
    public partial class PermisoDto : AuditableEntity, IMapFrom<ApplicationPermission>
    {
        public PermisoDto()
        {

        }
        public int Id { get; set; }
        public string Detalle { get; set; }
        public string Slug { get; set; }
        public int MenuRoleId { get; set; }
        public ApplicationMenuRole MenuRole { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ApplicationPermission, PermisoDto>();
        }
    }
}
