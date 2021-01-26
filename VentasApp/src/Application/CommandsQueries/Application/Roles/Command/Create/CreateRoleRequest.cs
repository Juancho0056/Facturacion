
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

namespace CommandsQueries.Application.Roles.Command.Create
{
    public class CreateRoleRequest : CommandRequest<ICollection<RoleDto>>, IValidatableObject
    {

        //RuleFor(v => v.Name)
        //        .Cascade(CascadeMode.StopOnFirstFailure)
        //        .MaximumLength(20).WithMessage("El nombre del rol debe tener una longitud maxima de 20 digitos")
        //        .NotEmpty().WithMessage("El nombre del rol es obligatorio.");
        //RuleFor(v => v.Description)
        //        .Cascade(CascadeMode.StopOnFirstFailure)
        //        .MaximumLength(60).WithMessage("La descripcion del rol debe tener una longitud maxima de 60 digitos")
        //        .NotEmpty().WithMessage("La descripcion del rol es obligatoria.");
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        [MaxLength(20, ErrorMessage = ErrorMessage.MaxLength + "20.")]
        public string Name { get; set; }
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        [MaxLength(60, ErrorMessage = ErrorMessage.MaxLength + "60.")]
        public string Description { get; set; }
        public IEnumerable<MvcControllerInfo> SelectedControllers { get; set; }
        public bool IsActive { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errores = new List<ValidationResult>();

            var _context = (IApplicationDbContext)validationContext.GetService(typeof(IApplicationDbContext));

            try
            {
                #region ApplicationRole
                var rol = _context.applicationroles
                    .AsNoTracking()
                    .Where(e => e.Name.ToLower().Contains(Name.ToLower()))
                    .FirstOrDefault();

                if (!(rol is null))
                {
                    errores.Add(new ValidationResult(ErrorMessage.Exist, new[] { "ApplicationRole" }));
                    return errores;
                }
                #endregion

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
