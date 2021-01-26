
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Exceptions;
using VentasApp.Application.Common.Interfaces;
using VentasApp.Domain.Enums;

namespace Application.CommandQueries.UnidadMedidas.Command.Update
{
    public class UpdateUnidadMedidaRequest : CommandRequest<ICollection<UnidadMedidaDto>>, IValidatableObject
    {

        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        public string Id { get; set; }
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        [MaxLength(80, ErrorMessage = ErrorMessage.MaxLength + "80.")]
        public string Detalle { get; set; }

        public bool? EstadoRegistro { get; set; }
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
