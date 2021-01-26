
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Interfaces;

namespace Application.CommandQueries.Menus.Command.Delete
{
    public class DeleteMenuHandler : CommandRequestHandler<DeleteMenuRequest, ICollection<MenuDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public DeleteMenuHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper) : base(context)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }
        public override async Task<ICollection<MenuDto>> HandleCommand(DeleteMenuRequest request, CancellationToken cancellationToken)
        {
            var vm = new List<MenuDto>();
            var entity = await _context.menus.Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            vm.Add(_mapper.Map<MenuDto>(entity));
            _context.menus.Remove(entity);
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

