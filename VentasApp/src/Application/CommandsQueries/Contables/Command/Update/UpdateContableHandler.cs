
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Interfaces;

namespace Application.CommandQueries.Contables.Command.Update
{
    public class UpdateContableHandler : CommandRequestHandler<UpdateContableRequest, ICollection<ContableDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public UpdateContableHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper) : base(context)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }
        public override async Task<ICollection<ContableDto>> HandleCommand(UpdateContableRequest request, CancellationToken cancellationToken)
        {
            var vm = new List<ContableDto>();
            var entity = await _context.contables.Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            if (!string.IsNullOrEmpty(request.Detalle)) 
            {
                entity.Detalle = request.Detalle;
            }
            if (request.IvaCompraId > 0) 
            {
                entity.IvaCompraId = request.IvaCompraId;
            }
            if (request.IvaVentaId > 0) 
            {
                entity.IvaVentaId = request.IvaVentaId;
            }
            if (request.ImpoConsumoId>0) 
            {
                entity.ImpoConsumoId = request.ImpoConsumoId;
            }
            entity.EstadoRegistro = request.EstadoRegistro ?? true;
            _context.contables.Update(entity);
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
            vm.Add(_mapper.Map<ContableDto>(entity));
            return vm;
        }
    }
}

