
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Exceptions;
using VentasApp.Application.Common.Interfaces;
using VentasApp.Domain.Enums;

namespace Application.CommandQueries.Articulos.Command.Update
{
    public class UpdateArticuloRequest : CommandRequest<ICollection<ArticuloDto>>, IValidatableObject
    {
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        public int Id { get; set; }
        public string Detalle { get; set; }
        public string Descripcion { get; set; }
        public decimal Factor { get; set; }
        public string Modelo { get; set; }
        public string Referencia { get; set; }
        public string Imagen { get; set; }
        public string Observacion { get; set; }
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        [EnumDataType(typeof(TipoCatalogo), ErrorMessage = ErrorMessage.IsEnum)]
        public TipoCatalogo TipoCatalogo { get; set; }
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        public int ClaseId { get; set; }
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        public int ContableId { get; set; }
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        public int GrupoId { get; set; }
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        public int MarcaId { get; set; }
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        public string UnidadMedidaId { get; set; }
        public bool EstadoRegistro { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errores = new List<ValidationResult>();
            var _context = (IApplicationDbContext)validationContext.GetService(typeof(IApplicationDbContext));

            try
            {
                var articulo = _context.articulos.
                    AsNoTracking().
                    Where(x => x.Id == Id).FirstOrDefault();

                if (articulo is null)
                {
                    errores.Add(new ValidationResult(ErrorMessage.NotFound("Articulo"), new[] { "Articulo" }));
                    return errores;
                }
                var articulonombre = _context.articulos.
                    AsNoTracking().
                    Where(x => x.Detalle == Detalle && x.Id != Id).FirstOrDefault();

                if (!(articulonombre is null))
                {
                    errores.Add(new ValidationResult(ErrorMessage.Exist, new[] { "Articulo" }));
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
