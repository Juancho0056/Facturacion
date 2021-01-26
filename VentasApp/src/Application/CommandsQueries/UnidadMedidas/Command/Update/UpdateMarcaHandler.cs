
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Interfaces;

namespace Application.CommandQueries.UnidadMedidas.Command.Update
{
    public class UpdateUnidadMedidaHandler : CommandRequestHandler<UpdateUnidadMedidaRequest, ICollection<UnidadMedidaDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public UpdateUnidadMedidaHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper) : base(context)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }
        public override async Task<ICollection<UnidadMedidaDto>> HandleCommand(UpdateUnidadMedidaRequest request, CancellationToken cancellationToken)
        {
            var vm = new List<UnidadMedidaDto>();
            var entity = await _context.unidadesmedidas.Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            if (!string.IsNullOrEmpty(request.Detalle)) 
            {
                entity.Detalle = request.Detalle;
            }
            entity.EstadoRegistro = request.EstadoRegistro ?? true;
            _context.unidadesmedidas.Update(entity);
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
            vm.Add(_mapper.Map<UnidadMedidaDto>(entity));
            return vm;
        }
    }
}

