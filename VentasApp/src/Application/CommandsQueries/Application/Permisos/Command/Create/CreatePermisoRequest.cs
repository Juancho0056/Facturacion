
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Exceptions;
using VentasApp.Application.Common.Interfaces;

namespace Application.CommandQueries.Permisos.Command.Create
{
    
    public class CreatePermisoRequest : CommandRequest<ICollection<PermisoDto>>, IValidatableObject
    {
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        [MaxLength(150, ErrorMessage = ErrorMessage.MaxLength + "150.")]
        public string Detalle { get; set; }
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        [MaxLength(150, ErrorMessage = ErrorMessage.MaxLength + "150.")]
        public string Slug { get; set; }
        public int MenuRoleId { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errores = new List<ValidationResult>();
            var _context = (IApplicationDbContext)validationContext.GetService(typeof(IApplicationDbContext));

            try
            {
                var menurole = _context.menusroles.
                    AsNoTracking().
                    Where(x => x.Id == MenuRoleId).FirstOrDefault();
                
                if (menurole is null)
                {
                    errores.Add(new ValidationResult(ErrorMessage.NotFound("Menu"), new[] { "MenuRoleId" }));
                    return errores;
                }
                var permiso = _context.permissions.
                    AsNoTracking().
                    Where(x => x.Slug == Slug).FirstOrDefault();

                if (!(permiso is null))
                {
                    errores.Add(new ValidationResult(ErrorMessage.Exist, new[] { "Permiso" }));
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
