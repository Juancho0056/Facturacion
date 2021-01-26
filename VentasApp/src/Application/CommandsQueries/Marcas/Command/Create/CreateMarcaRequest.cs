
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Exceptions;
using VentasApp.Application.Common.Interfaces;
using VentasApp.Domain.Enums;

namespace Application.CommandQueries.Marcas.Command.Create
{
    
    public class CreateMarcaRequest : CommandRequest<ICollection<MarcaDto>>, IValidatableObject
    {
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        [MaxLength(80, ErrorMessage = ErrorMessage.MaxLength + "80.")]
        public string Detalle { get; set; }
        public TipoCatalogo TipoCatalogo { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errores = new List<ValidationResult>();
            var _context = (IApplicationDbContext)validationContext.GetService(typeof(IApplicationDbContext));

            try
            {
                var marca = _context.marcas.
                    AsNoTracking().
                    Where(x => x.Detalle == Detalle).FirstOrDefault();
                
                if (!(marca is null))
                {
                    errores.Add(new ValidationResult(ErrorMessage.Exist, new[] { "Marca" }));
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
