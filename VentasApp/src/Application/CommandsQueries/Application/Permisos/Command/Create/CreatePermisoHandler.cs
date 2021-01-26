using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Interfaces;
using VentasApp.Domain.Entities.Application;

namespace Application.CommandQueries.Permisos.Command.Create
{
    public class CreatePermisoHandler : CommandRequestHandler<CreatePermisoRequest, ICollection<PermisoDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CreatePermisoHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper) : base(context)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }
        public override async Task<ICollection<PermisoDto>> HandleCommand(CreatePermisoRequest request, CancellationToken cancellationToken)
        {
            var vm = new List<PermisoDto>();
            ApplicationPermission permiso = new ApplicationPermission
            {
                Detalle = request.Detalle,
                Slug = request.Slug,
                MenuRoleId = request.MenuRoleId
            };
            _context.permissions.Add(permiso);
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
            vm.Add(_mapper.Map<PermisoDto>(permiso));
            return vm;
        }
    }
}

