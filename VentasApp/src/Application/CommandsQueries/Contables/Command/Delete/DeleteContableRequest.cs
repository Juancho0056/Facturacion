
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Exceptions;
using VentasApp.Application.Common.Interfaces;

namespace Application.CommandQueries.Contables.Command.Delete
{
    public class DeleteContableRequest : CommandRequest<ICollection<ContableDto>>, IValidatableObject
    {
        [Required(ErrorMessage =ErrorMessage.IsRequired)]
        public int Id { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errores = new List<ValidationResult>();
            var _context = (IApplicationDbContext)validationContext.GetService(typeof(IApplicationDbContext));

            try
            {
                var contable = _context.contables.
                    AsNoTracking().
                    Where(x => x.Id == Id).FirstOrDefault();

                if (contable is null)
                {
                    errores.Add(new ValidationResult(ErrorMessage.NotFound("Contable"), new[] { "Contable" }));
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
