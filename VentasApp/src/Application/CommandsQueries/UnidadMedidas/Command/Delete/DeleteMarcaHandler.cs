
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Interfaces;

namespace Application.CommandQueries.UnidadMedidas.Command.Delete
{
    public class DeleteUnidadMedidaHandler : CommandRequestHandler<DeleteUnidadMedidaRequest, ICollection<UnidadMedidaDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public DeleteUnidadMedidaHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper) : base(context)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }
        public override async Task<ICollection<UnidadMedidaDto>> HandleCommand(DeleteUnidadMedidaRequest request, CancellationToken cancellationToken)
        {
            var vm = new List<UnidadMedidaDto>();
            var entity = await _context.unidadesmedidas.Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            vm.Add(_mapper.Map<UnidadMedidaDto>(entity));
            _context.unidadesmedidas.Remove(entity);
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
            return vm;
        }
    }
}

