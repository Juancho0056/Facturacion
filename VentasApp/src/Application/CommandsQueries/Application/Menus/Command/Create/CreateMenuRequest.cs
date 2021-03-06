﻿
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Exceptions;
using VentasApp.Application.Common.Interfaces;

namespace Application.CommandQueries.Menus.Command.Create
{
    
    public class CreateMenuRequest : CommandRequest<ICollection<MenuDto>>, IValidatableObject
    {
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        [MaxLength(70, ErrorMessage = ErrorMessage.MaxLength + "70.")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        [MaxLength(40, ErrorMessage = ErrorMessage.MaxLength + "40.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        [MaxLength(70, ErrorMessage = ErrorMessage.MaxLength + "70.")]
        public string Url { get; set; }
        public Nullable<int> Padre { get; set; }
        public Nullable<int> PaginaId { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errores = new List<ValidationResult>();
            var _context = (IApplicationDbContext)validationContext.GetService(typeof(IApplicationDbContext));

            try
            {
                var menu = _context.menus.
                    AsNoTracking().
                    Where(x => x.Nombre == Nombre || x.Titulo == Titulo).FirstOrDefault();
                
                if (!(menu is null))
                {
                    errores.Add(new ValidationResult(ErrorMessage.Exist, new[] { "Menu" }));
                    return errores;
                }
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
