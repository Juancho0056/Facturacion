
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Exceptions;
using VentasApp.Application.Common.Interfaces;
using VentasApp.Domain.Enums;

namespace Application.CommandQueries.Contables.Command.Create
{
    
    public class CreateContableRequest : CommandRequest<ICollection<ContableDto>>, IValidatableObject
    {
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        [MaxLength(80, ErrorMessage = ErrorMessage.MaxLength + "80.")]
        public string Detalle { get; set; }
        [Required(ErrorMessage=ErrorMessage.IsRequired)]
        public int IvaVentaId { get; set; }
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        public int IvaCompraId { get; set; }
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        public int ImpoConsumoId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errores = new List<ValidationResult>();
            var _context = (IApplicationDbContext)validationContext.GetService(typeof(IApplicationDbContext));

            try
            {
                var contable = _context.contables.
                    AsNoTracking().
                    Where(x => x.Detalle == Detalle).FirstOrDefault();
                
                if (!(contable is null))
                {
                    errores.Add(new ValidationResult(ErrorMessage.Exist, new[] { "Contable" }));
                    return errores;
                }
                var ivac = _context.ivas.
                    AsNoTracking().
                    Where(x => x.Id == IvaCompraId).FirstOrDefault();

                if (ivac is null)
                {
                    errores.Add(new ValidationResult(ErrorMessage.NotFound("Iva"), new[] { "IvaCompraId" }));
                    return errores;
                }
                var ivav = _context.ivas.
                    AsNoTracking().
                    Where(x => x.Id == IvaVentaId).FirstOrDefault();

                if (ivac is null)
                {
                    errores.Add(new ValidationResult(ErrorMessage.NotFound("Iva"), new[] { "IvaVentaId" }));
                    return errores;
                }
                var impoconsumo = _context.impoconsumos.
                    AsNoTracking().
                    Where(x => x.Id == ImpoConsumoId).FirstOrDefault();

                if (impoconsumo is null)
                {
                    errores.Add(new ValidationResult(ErrorMessage.NotFound("ImpoConsumo"), new[] { "ImpoConsumoId" }));
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
