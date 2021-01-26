using Application.Application.Roles;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Exceptions;
using VentasApp.Application.Common.Interfaces;

namespace CommandsQueries.Application.Roles.Command.Delete
{
    public class DeleteRoleRequest : CommandRequest<ICollection<RoleDto>>, IValidatableObject
    {
        public Guid Id { get; set; }
        public  IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errores = new List<ValidationResult>();
            var _context = (IApplicationDbContext)validationContext.GetService(typeof(IApplicationDbContext));
            try
            {
                var role = _context.applicationroles
                .Find(Id);
                if (role is null)
                {
                    errores.Add(new ValidationResult(ErrorMessage.NotFound("ApplicationRole"), new[] { "ApplicationRole" }));
                    return errores;
                }
                var hasRoles = _context.applicationuserroles.Find(Id);
                if (hasRoles!=null)
                {
                    errores.Add(new ValidationResult(ErrorMessage.InUse("ApplicationRole"), new[] { "ApplicationRole"}));
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
