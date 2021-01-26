
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Interfaces;

namespace Application.CommandQueries.Clases.Command.Delete
{
    public class DeleteClaseHandler : CommandRequestHandler<DeleteClaseRequest, ICollection<ClaseDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public DeleteClaseHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper) : base(context)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }
        public override async Task<ICollection<ClaseDto>> HandleCommand(DeleteClaseRequest request, CancellationToken cancellationToken)
        {
            var vm = new List<ClaseDto>();
            var entity = await _context.clases.Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            vm.Add(_mapper.Map<ClaseDto>(entity));
            _context.clases.Remove(entity);
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

