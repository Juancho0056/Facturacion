using Application.Application.UserRoles;
using AutoMapper;
using Domain.Entities.Application;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Interfaces;

namespace Application.Application.UserRoles.Command.Create
{
    public class CreateUserRoleHandler : CommandRequestHandler<CreateUserRoleRequest, ICollection<UserRoleDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CreateUserRoleHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper) : base(context)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }
        
        public override async Task<ICollection<UserRoleDto>> HandleCommand(CreateUserRoleRequest request, CancellationToken cancellationToken)
        {
            var vm = new List<UserRoleDto>();
            ApplicationUserRole userrole = new ApplicationUserRole
            {
                RoleId = request.RoleId,
                UserId = request.UserId
            };
            _context.applicationuserroles.Add(userrole);
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
            vm.Add(_mapper.Map<UserRoleDto>(userrole));
            return vm;
        }


    }
}

