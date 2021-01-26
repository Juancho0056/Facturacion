
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Exceptions;
using VentasApp.Application.Common.Interfaces;

namespace Application.CommandQueries.Paginas.Command.Delete
{
    public class DeletePaginaRequest : CommandRequest<PaginaDto>, IValidatableObject
    {
        [Required(ErrorMessage =ErrorMessage.IsRequired)]
        public int Id { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errores = new List<ValidationResult>();
            var _context = (IApplicationDbContext)validationContext.GetService(typeof(IApplicationDbContext));

            try
            {
                var pagina = _context.paginas.
                    AsNoTracking().
                    Where(x => x.Id == Id).FirstOrDefault();

                if (pagina is null)
                {
                    errores.Add(new ValidationResult(ErrorMessage.NotFound("Pagina"), new[] { "Pagina" }));
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
