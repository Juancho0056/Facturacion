
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Exceptions;
using VentasApp.Application.Common.Interfaces;
using VentasApp.Domain.Enums;

namespace Application.CommandQueries.Contables.Command.Update
{
    public class UpdateContableRequest : CommandRequest<ICollection<ContableDto>>, IValidatableObject
    {

        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        public int Id { get; set; }
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        [MaxLength(80, ErrorMessage = ErrorMessage.MaxLength + "80.")]
        public string Detalle { get; set; }
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        public int IvaVentaId { get; set; }
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        public int IvaCompraId { get; set; }
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        public int ImpoConsumoId { get; set; }

        public bool? EstadoRegistro { get; set; }
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
