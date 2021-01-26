using Application.Application.Roles;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Interfaces;
using VentasApp.Application.Common.Results;

namespace CommandsQueries.Application.Roles.Command.Delete
{
    public class DeleteRoleHandler : CommandRequestHandler<DeleteRoleRequest, ICollection<RoleDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public DeleteRoleHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper) : base(context)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }
        
        public override async Task<ICollection<RoleDto>> HandleCommand(DeleteRoleRequest request, CancellationToken cancellationToken)
        {
            var vm = new List<RoleDto>();
            var entity = await _context.applicationroles
                .FindAsync(request.Id);
            vm.Add(_mapper.Map<RoleDto>(entity));

            
            _context.applicationroles.Remove(entity);
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

