
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Exceptions;
using VentasApp.Application.Common.Interfaces;

namespace Application.CommandQueries.UnidadMedidas.Command.Delete
{
    public class DeleteUnidadMedidaRequest : CommandRequest<ICollection<UnidadMedidaDto>>, IValidatableObject
    {
        [Required(ErrorMessage =ErrorMessage.IsRequired)]
        public string Id { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errores = new List<ValidationResult>();
            var _context = (IApplicationDbContext)validationContext.GetService(typeof(IApplicationDbContext));

            try
            {
                var unidadmedida = _context.unidadesmedidas.
                    AsNoTracking().
                    Where(x => x.Id == Id).FirstOrDefault();

                if (unidadmedida is null)
                {
                    errores.Add(new ValidationResult(ErrorMessage.NotFound("UnidadMedida"), new[] { "UnidadMedida" }));
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
