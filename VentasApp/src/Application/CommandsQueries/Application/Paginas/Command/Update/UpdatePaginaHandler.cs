
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Interfaces;

namespace Application.CommandQueries.Paginas.Command.Update
{
    public class UpdatePaginaHandler : CommandRequestHandler<UpdatePaginaRequest, PaginaDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public UpdatePaginaHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper) : base(context)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }
        public override async Task<PaginaDto> HandleCommand(UpdatePaginaRequest request, CancellationToken cancellationToken)
        {
            var vm = new List<PaginaDto>();
            var entity = await _context.paginas.Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            if (!string.IsNullOrEmpty(request.Nombre)) 
            {
                entity.Nombre = request.Nombre;
            }
            if (!string.IsNullOrEmpty(request.Titulo))
            {
                entity.Titulo = request.Titulo;
            }
            if (!string.IsNullOrEmpty(request.Proyecto))
            {
                entity.Proyecto = request.Proyecto;
            }
            if (!string.IsNullOrEmpty(request.Url))
            {
                entity.Url = request.Url;
            }
            entity.EstadoRegistro = request.EstadoRegistro ?? true;
            _context.paginas.Update(entity);
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
            return _mapper.Map<PaginaDto>(entity);
            
        }
    }
}

