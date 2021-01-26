using Application.Application.MenuRoles;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Exceptions;
using VentasApp.Application.Common.Interfaces;

namespace Application.Application.MenuRoles.Command.Create
{
    public class CreateMenuRoleRequest : CommandRequest<ICollection<MenuRoleDto>>, IValidatableObject
    {
        public int MenuId { get; set; }
        public string RoleId { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errores = new List<ValidationResult>();
            var _context = (IApplicationDbContext)validationContext.GetService(typeof(IApplicationDbContext));

            try
            {
                
                var role =  _context.applicationroles.AsNoTracking().Where(x => x.Id == RoleId)
                    .FirstOrDefault();

                if (role == null)
                {
                    errores.Add(new ValidationResult(ErrorMessage.NotFound("ApplicationRole"), new[] { "RoleId" }));
                    return errores;
                }
                
                
                var menu = _context.menus.AsNoTracking().Where(x => x.Id == MenuId)
                    .FirstOrDefault();

                if (menu == null)
                {
                    errores.Add(new ValidationResult(ErrorMessage.NotFound("ApplicationRole"), new[] { "MenuId" }));
                    return errores;
                }

                var entity = _context.menusroles.Where(x => x.MenuId == MenuId
                && x.RoleId == RoleId).FirstOrDefault();
                if (entity != null)
                {
                    errores.Add(new ValidationResult(ErrorMessage.Exist, new[] { "ApplicationMenuRole" }));
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
