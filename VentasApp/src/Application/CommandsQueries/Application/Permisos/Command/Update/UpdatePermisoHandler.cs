
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Interfaces;

namespace Application.CommandQueries.Permisos.Command.Update
{
    public class UpdatePermisoHandler : CommandRequestHandler<UpdatePermisoRequest, ICollection<PermisoDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public UpdatePermisoHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper) : base(context)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }
        public override async Task<ICollection<PermisoDto>> HandleCommand(UpdatePermisoRequest request, CancellationToken cancellationToken)
        {
            var vm = new List<PermisoDto>();
            var entity = await _context.permissions.Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            if (!string.IsNullOrEmpty(request.Detalle)) 
            {
                entity.Detalle = request.Detalle;
            }
            if (!string.IsNullOrEmpty(request.Slug))
            {
                entity.Slug = request.Slug;
            }
            if (request.MenuRoleId > 0)
            {
                entity.MenuRoleId = request.MenuRoleId;
            }
            entity.EstadoRegistro = request.EstadoRegistro ?? true;
            _context.permissions.Update(entity);
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
            vm.Add(_mapper.Map<PermisoDto>(entity));
            return vm;
        }
    }
}

