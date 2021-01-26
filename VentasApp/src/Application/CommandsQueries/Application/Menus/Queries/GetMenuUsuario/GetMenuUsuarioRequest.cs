using Application.CommandQueries.Menus;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Exceptions;
using VentasApp.Application.Common.Interfaces;

namespace VentasApp.Application.CommandsQueries.Application.Menus.Queries.GetMenuUsuario
{
    public class GetMenuUsuarioRequest : QueryRequest<MenuUsuarioList>, IValidatableObject
    {
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        [JsonIgnore]
        public string Username { get; set; }
        public int? Padre { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errores = new List<ValidationResult>();
            var _context = (IApplicationDbContext)validationContext.GetService(typeof(IApplicationDbContext));

            try
            {
                if (Padre > 0)
                {
                    var padre = _context.menus.
                        AsNoTracking().
                        Where(x => x.Id == Padre).FirstOrDefault();
                    if (padre is null)
                    {
                        errores.Add(new ValidationResult(ErrorMessage.NotFound("Menu"), new[] { "Padre" }));
                        return errores;
                    }
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
