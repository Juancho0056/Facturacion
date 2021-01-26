
using Application.Application.MenuRoles;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Interfaces;

namespace GESTION.API.Application.Application.MenuRoles.Command.Delete
{
    public class DeleteMenuRoleHandler : CommandRequestHandler<DeleteMenuRoleRequest, ICollection<MenuRoleDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public DeleteMenuRoleHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper) : base(context)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }

        public override async Task<ICollection<MenuRoleDto>> HandleCommand(DeleteMenuRoleRequest request, CancellationToken cancellationToken)
        {
            var vm = new List<MenuRoleDto>();
            var entity = await _context.menusroles.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            vm.Add(_mapper.Map<MenuRoleDto>(entity));


            _context.menusroles.Remove(entity);
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

