
using Application.Application.UserRoles;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Interfaces;

namespace GESTION.API.Application.Application.UserRoles.Command.Delete
{
    public class DeleteUserRoleHandler : CommandRequestHandler<DeleteUserRoleRequest, ICollection<UserRoleDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public DeleteUserRoleHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper) : base(context)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }

        public override async Task<ICollection<UserRoleDto>> HandleCommand(DeleteUserRoleRequest request, CancellationToken cancellationToken)
        {
            var vm = new List<UserRoleDto>();
            var entity = await _context.applicationroles
                .FindAsync(request.RoleId, request.UserId);
            vm.Add(_mapper.Map<UserRoleDto>(entity));


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

