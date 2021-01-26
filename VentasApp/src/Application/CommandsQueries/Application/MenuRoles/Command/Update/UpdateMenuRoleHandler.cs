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

namespace Application.Application.MenuRoles.Command.Update
{
    public class UpdateMenuRoleHandler : CommandRequestHandler<UpdateMenuRoleRequest, ICollection<MenuRoleDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public UpdateMenuRoleHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper) : base(context)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }
        
        public override async Task<ICollection<MenuRoleDto>> HandleCommand(UpdateMenuRoleRequest request, CancellationToken cancellationToken)
        {
            var vm = new List<MenuRoleDto>();
            var entity = await _context.menusroles.Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            if (request.MenuId > 0) 
            {
                entity.MenuId = request.MenuId;
            }
            if (!string.IsNullOrEmpty(request.RoleId)) 
            {
                entity.RoleId = request.RoleId;
            }
            _context.menusroles.Update(entity);
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
            vm.Add(_mapper.Map<MenuRoleDto>(entity));
            return vm;
        }


    }
}

