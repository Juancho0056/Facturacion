
using Application.Application.Roles;
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
using VentasApp.Domain.Common;

namespace CommandsQueries.Application.Roles.Command.Update
{
    public class UpdateRoleRequest: CommandRequest<ICollection<RoleDto>>, IValidatableObject
    {
        [Required]
        public string Id { get; set; }
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        [MaxLength(20, ErrorMessage = ErrorMessage.MaxLength + "20.")]
        public string Name { get; set; }
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        [MaxLength(60, ErrorMessage = ErrorMessage.MaxLength + "60.")]
        public string Description { get; set; }
        public IEnumerable<MvcControllerInfo> SelectedControllers { get; set; }
        public bool EstadoRegistro { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errores = new List<ValidationResult>();
            var _context = (IApplicationDbContext)validationContext.GetService(typeof(IApplicationDbContext));

            try
            {
                var role = _context.applicationroles.
                    AsNoTracking().
                    Where(x => x.Id == Id).FirstOrDefault();

                if (role is null)
                {
                    errores.Add(new ValidationResult(ErrorMessage.NotFound("ApplicationRole"), new[] { "ApplicationRole" }));
                }
                var rol = _context.applicationroles
                    .AsNoTracking()
                    .Where(e => e.Name.ToLower().Contains(Name.ToLower()))
                    .FirstOrDefault();
                if (!(rol is null) && rol.Id != Id)
                {
                    errores.Add(new ValidationResult("Ya existe un rol con el nombre ingresado", new[] { "ApplicationRole" }));
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