using Application.Application.Roles;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Interfaces;

namespace CommandsQueries.Application.Roles.Command.Update
{
    public class UpdateRoleHandler : CommandRequestHandler<UpdateRoleRequest, ICollection<RoleDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public UpdateRoleHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper) : base(context)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }
        public override async Task<ICollection<RoleDto>> HandleCommand(UpdateRoleRequest request, CancellationToken cancellationToken)
        {
            var vm = new List<RoleDto>();
            var entity = await _context.applicationroles.Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            if (!string.IsNullOrEmpty(request.Name))
            {
                entity.Name = request.Name;
            }
            if (!string.IsNullOrEmpty(request.Description))
            {
                entity.Description = request.Description;
            }
            entity.EstadoRegistro = request.EstadoRegistro;
            _context.applicationroles.Update(entity);
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
            vm.Add(_mapper.Map<RoleDto>(entity));
            return vm;
        }
    }
}
