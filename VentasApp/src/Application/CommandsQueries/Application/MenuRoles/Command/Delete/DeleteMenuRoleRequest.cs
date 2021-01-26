using Application.Application.MenuRoles;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Exceptions;
using VentasApp.Application.Common.Interfaces;

namespace GESTION.API.Application.Application.MenuRoles.Command.Delete
{
    public class DeleteMenuRoleRequest : CommandRequest<ICollection<MenuRoleDto>>, IValidatableObject
    {
        [Required]
        public int Id { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errores = new List<ValidationResult>();
            var _context = (IApplicationDbContext)validationContext.GetService(typeof(IApplicationDbContext));

            try
            {

                var role = _context.menusroles.AsNoTracking().Where(x => x.Id == Id)
                    .FirstOrDefault();

                if (role == null)
                {
                    errores.Add(new ValidationResult(ErrorMessage.NotFound("ApplicationMenuRole"), new[] { "Id" }));
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
