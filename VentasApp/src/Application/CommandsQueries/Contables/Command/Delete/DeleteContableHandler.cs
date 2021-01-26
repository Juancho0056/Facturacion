
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Interfaces;

namespace Application.CommandQueries.Contables.Command.Delete
{
    public class DeleteContableHandler : CommandRequestHandler<DeleteContableRequest, ICollection<ContableDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public DeleteContableHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper) : base(context)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }
        public override async Task<ICollection<ContableDto>> HandleCommand(DeleteContableRequest request, CancellationToken cancellationToken)
        {
            var vm = new List<ContableDto>();
            var entity = await _context.contables.Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            vm.Add(_mapper.Map<ContableDto>(entity));
            _context.contables.Remove(entity);
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

