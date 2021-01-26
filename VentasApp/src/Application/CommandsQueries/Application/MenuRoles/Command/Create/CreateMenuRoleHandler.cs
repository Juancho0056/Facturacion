using Application.Application.MenuRoles;
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
using VentasApp.Domain.Entities.Application;

namespace Application.Application.MenuRoles.Command.Create
{
    public class CreateMenuRoleHandler : CommandRequestHandler<CreateMenuRoleRequest, ICollection<MenuRoleDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CreateMenuRoleHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper) : base(context)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }
        
        public override async Task<ICollection<MenuRoleDto>> HandleCommand(CreateMenuRoleRequest request, CancellationToken cancellationToken)
        {
            var vm = new List<MenuRoleDto>();
            ApplicationMenuRole menurole = new ApplicationMenuRole
            {
                RoleId = request.RoleId,
                MenuId = request.MenuId
            };
            _context.menusroles.Add(menurole);
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
            vm.Add(_mapper.Map<MenuRoleDto>(menurole));
            return vm;
        }


    }
}

