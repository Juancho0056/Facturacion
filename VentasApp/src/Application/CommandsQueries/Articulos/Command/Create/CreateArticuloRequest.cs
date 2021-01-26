
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Exceptions;
using VentasApp.Application.Common.Interfaces;
using VentasApp.Domain.Enums;

namespace Application.CommandQueries.Articulos.Command.Create
{
    
    public class CreateArticuloRequest : CommandRequest<ICollection<ArticuloDto>>, IValidatableObject
    {
        public string Detalle { get; set; }
        public string Descripcion { get; set; }
        public decimal Factor { get; set; }
        public string Modelo { get; set; }
        public string Referencia { get; set; }
        public string Imagen { get; set; }
        public string Observacion { get; set; }
        [Required(ErrorMessage=ErrorMessage.IsRequired)]
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


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errores = new List<ValidationResult>();
            var _context = (IApplicationDbContext)validationContext.GetService(typeof(IApplicationDbContext));

            try
            {
                
                var clase = _context.clases.
                    AsNoTracking().
                    Where(x => x.Id == ClaseId).FirstOrDefault();

                if (clase is null)
                {
                    errores.Add(new ValidationResult(ErrorMessage.NotFound("Clase"), new[] { "ClaseId" }));
                    return errores;
                }
                var contable = _context.contables.
                    AsNoTracking().
                    Where(x => x.Id == ContableId).FirstOrDefault();

                if (contable is null)
                {
                    errores.Add(new ValidationResult(ErrorMessage.NotFound("Contable"), new[] { "ContableId" }));
                    return errores;
                }
                var grupo = _context.grupos.
                    AsNoTracking().
                    Where(x => x.Id == GrupoId).FirstOrDefault();

                if (grupo is null)
                {
                    errores.Add(new ValidationResult(ErrorMessage.NotFound("Grupo"), new[] { "GrupoId" }));
                    return errores;
                }
                var marca = _context.marcas.
                   AsNoTracking().
                   Where(x => x.Id == MarcaId).FirstOrDefault();

                if (marca is null)
                {
                    errores.Add(new ValidationResult(ErrorMessage.NotFound("Marca"), new[] { "MarcaId" }));
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
