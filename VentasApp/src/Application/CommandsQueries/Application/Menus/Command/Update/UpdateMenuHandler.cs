
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Interfaces;

namespace Application.CommandQueries.Menus.Command.Update
{
    public class UpdateMenuHandler : CommandRequestHandler<UpdateMenuRequest, ICollection<MenuDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public UpdateMenuHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper) : base(context)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }
        public override async Task<ICollection<MenuDto>> HandleCommand(UpdateMenuRequest request, CancellationToken cancellationToken)
        {
            var vm = new List<MenuDto>();
            var entity = await _context.menus.Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            if (!string.IsNullOrEmpty(request.Titulo)) 
            {
                entity.Titulo = request.Titulo;
            }
            if (!string.IsNullOrEmpty(request.Nombre)) 
            {
                entity.Nombre = request.Nombre;
            }
            if (!string.IsNullOrEmpty(request.Url))
            { 
                entity.Url = request.Url;
            }
            if (request.Padre > 0)
            {
                entity.Padre = request.Padre;
            }
            if (request.PaginaId > 0)
            {
                entity.PaginaId = request.PaginaId;
            }
            entity.EstadoRegistro = request.EstadoRegistro ?? true;
            _context.menus.Update(entity);
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
            vm.Add(_mapper.Map<MenuDto>(entity));
            return vm;
        }
    }
}

