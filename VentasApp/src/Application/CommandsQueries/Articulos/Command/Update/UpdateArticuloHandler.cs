using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Interfaces;

namespace Application.CommandQueries.Articulos.Command.Update
{
    public class UpdateArticuloHandler : CommandRequestHandler<UpdateArticuloRequest, ICollection<ArticuloDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public UpdateArticuloHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper) : base(context)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }
        public override async Task<ICollection<ArticuloDto>> HandleCommand(UpdateArticuloRequest request, CancellationToken cancellationToken)
        {
            var vm = new List<ArticuloDto>();
            var entity = await _context.articulos.Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            if (!string.IsNullOrEmpty(request.Detalle)) 
            {
                entity.Detalle = request.Detalle;
            }
            if (!string.IsNullOrEmpty(request.Descripcion))
            {
                entity.Descripcion = request.Descripcion;
            }
            if (request.Factor > 0)
            {
                entity.Factor = request.Factor;
            }
            if (!string.IsNullOrEmpty(request.Modelo))
            {
                entity.Modelo = request.Modelo;
            }
            if (!string.IsNullOrEmpty(request.Referencia))
            {
                entity.Referencia = request.Referencia;
            }
            if (!string.IsNullOrEmpty(request.Imagen))
            {
                entity.Imagen = request.Imagen;
            }
            if (!string.IsNullOrEmpty(request.Observacion))
            {
                entity.Observacion = request.Observacion;
            }
            entity.TipoCatalogo = ((char)request.TipoCatalogo).ToString();
            
            if (request.ClaseId > 0)
            {
                entity.ClaseId = request.ClaseId;
            }
            if (request.ContableId > 0)
            {
                entity.ContableId = request.ContableId;
            }
            if (request.GrupoId > 0)
            {
                entity.GrupoId = request.GrupoId;
            }
            if (request.MarcaId > 0)
            {
                entity.MarcaId = request.MarcaId;
            }
            if (!string.IsNullOrEmpty(request.UnidadMedidaId))
            {
                entity.UnidadMedidaId = request.UnidadMedidaId;
            }
            entity.EstadoRegistro = request.EstadoRegistro;
            _context.articulos.Update(entity);
            try
            {
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                _context.RollbackTransaction();
                _context.DetachAll();
                return await HandleCommand(request, cancellationToken);
            }
            vm.Add(_mapper.Map<ArticuloDto>(entity));
            return vm;
        }
    }
}

