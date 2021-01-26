using Application.Application.Roles;
using AutoMapper;
using Domain.Entities.Application;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Interfaces;

namespace CommandsQueries.Application.Roles.Command.Create
{
    public class CreateRoleHandler : CommandRequestHandler<CreateRoleRequest, ICollection<RoleDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CreateRoleHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper) : base(context)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }
        public override async Task<ICollection<RoleDto>> HandleCommand(CreateRoleRequest request, CancellationToken cancellationToken)
        {
            var vm = new List<RoleDto>();
            ApplicationRole role = new ApplicationRole
            {
                Name = request.Name,
                Description = request.Description,
                NormalizedName = request.Name.ToUpper()

            };
            if (request.SelectedControllers != null && request.SelectedControllers.Any())
            {
                foreach (var controller in request.SelectedControllers)
                    foreach (var action in controller.Actions)
                        action.ControllerId = controller.Id;

                var accessJson = JsonConvert.SerializeObject(request.SelectedControllers);
                role.Access = accessJson;
            }
            _context.applicationroles.Add(role);
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
            vm.Add(_mapper.Map<RoleDto>(role));
            return vm;
        }
    }
}

