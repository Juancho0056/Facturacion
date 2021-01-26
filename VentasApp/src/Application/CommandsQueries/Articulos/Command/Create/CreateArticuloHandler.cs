using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Interfaces;

namespace Application.CommandQueries.Articulos.Command.Create
{
    public class CreateArticuloHandler : CommandRequestHandler<CreateArticuloRequest, ICollection<ArticuloDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CreateArticuloHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper) : base(context)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }
        public override async Task<ICollection<ArticuloDto>> HandleCommand(CreateArticuloRequest request, CancellationToken cancellationToken)
        {
            var vm = new List<ArticuloDto>();
            Articulo bien = new Articulo
            {
                Detalle = request.Detalle,
                Descripcion = request.Descripcion,
                Factor = request.Factor,
                Modelo = request.Modelo,
                Referencia = request.Referencia,
                Imagen = request.Imagen,
                Observacion = request.Observacion,
                TipoCatalogo = ((char)request.TipoCatalogo).ToString(),
                ClaseId = request.ClaseId,
                ContableId = request.ContableId,
                GrupoId = request.GrupoId,
                MarcaId = request.MarcaId,
                UnidadMedidaId = request.UnidadMedidaId
            };
            _context.articulos.Add(bien);
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
            vm.Add(_mapper.Map<ArticuloDto>(bien));
            return vm;
        }

     
    }
}

