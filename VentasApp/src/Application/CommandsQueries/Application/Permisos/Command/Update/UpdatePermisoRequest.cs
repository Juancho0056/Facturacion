
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Exceptions;
using VentasApp.Application.Common.Interfaces;
using VentasApp.Domain.Enums;

namespace Application.CommandQueries.Permisos.Command.Update
{
    public class UpdatePermisoRequest : CommandRequest<ICollection<PermisoDto>>, IValidatableObject
    {

        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        public int Id { get; set; }
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        [MaxLength(150, ErrorMessage = ErrorMessage.MaxLength + "150.")]
        public string Detalle { get; set; }
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        [MaxLength(150, ErrorMessage = ErrorMessage.MaxLength + "150.")]
        public string Slug { get; set; }
        public int MenuRoleId { get; set; }
        public bool? EstadoRegistro { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errores = new List<ValidationResult>();
            var _context = (IApplicationDbContext)validationContext.GetService(typeof(IApplicationDbContext));

            try
            {
                var permiso = _context.permissions.
                    AsNoTracking().
                    Where(x => x.Id == Id).FirstOrDefault();

                if (permiso is null)
                {
                    errores.Add(new ValidationResult(ErrorMessage.NotFound("ApplicationPermission"), new[] { "Id" }));
                    return errores;
                }
                var permisoSlug = _context.permissions.
                    AsNoTracking().
                    Where(x => x.Slug == Slug).FirstOrDefault();

                if (permisoSlug is null)
                {
                    errores.Add(new ValidationResult(ErrorMessage.Exist, new[] { "Slug" }));
                    return errores;
                }
                return errores;
            }
            catch (Exception e)
            {
                errores.Add(new ValidationResult(e.Message));
                return errores;
            }
        }
    }
}
