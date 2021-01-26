
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Exceptions;
using VentasApp.Application.Common.Interfaces;

namespace Application.CommandQueries.Menus.Command.Delete
{
    public class DeleteMenuRequest : CommandRequest<ICollection<MenuDto>>, IValidatableObject
    {
        [Required(ErrorMessage =ErrorMessage.IsRequired)]
        public int Id { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errores = new List<ValidationResult>();
            var _context = (IApplicationDbContext)validationContext.GetService(typeof(IApplicationDbContext));

            try
            {
                var menu = _context.menus.
                    AsNoTracking().
                    Where(x => x.Id == Id).FirstOrDefault();

                if (menu is null)
                {
                    errores.Add(new ValidationResult(ErrorMessage.NotFound("Menu"), new[] { "Menu" }));
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
