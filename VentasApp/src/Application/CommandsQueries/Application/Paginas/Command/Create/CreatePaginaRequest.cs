
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Exceptions;
using VentasApp.Application.Common.Interfaces;
using VentasApp.Domain.Enums;

namespace Application.CommandQueries.Paginas.Command.Create
{
    
    public class CreatePaginaRequest : CommandRequest<PaginaDto>, IValidatableObject
    {
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        [MaxLength(40, ErrorMessage = ErrorMessage.MaxLength + "40.")]
        [MinLength(5, ErrorMessage = ErrorMessage.MinLength + "5.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        [MaxLength(70, ErrorMessage = ErrorMessage.MaxLength + "70.")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        [MaxLength(70, ErrorMessage = ErrorMessage.MaxLength + "70.")]
        public string Proyecto { get; set; }
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        [MaxLength(200, ErrorMessage = ErrorMessage.MaxLength + "200.")]
        public string Url { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errores = new List<ValidationResult>();
            var _context = (IApplicationDbContext)validationContext.GetService(typeof(IApplicationDbContext));

            try
            {
                var pagina = _context.paginas.
                    AsNoTracking().
                    Where(x => x.Nombre == Nombre).FirstOrDefault();
                
                if (!(pagina is null))
                {
                    errores.Add(new ValidationResult(ErrorMessage.Exist, new[] { "Pagina" }));
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
