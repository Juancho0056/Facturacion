using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Interfaces;
using VentasApp.Domain.Entities.Application;

namespace Application.CommandQueries.Paginas.Command.Create
{
    public class CreatePaginaHandler : CommandRequestHandler<CreatePaginaRequest, PaginaDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CreatePaginaHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper) : base(context)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }
        public override async Task<PaginaDto> HandleCommand(CreatePaginaRequest request, CancellationToken cancellationToken)
        {
            ApplicationPagina pagina = new ApplicationPagina
            {
                Nombre = request.Nombre,
                Titulo =request.Titulo,
                Url =request.Url,
                Proyecto = request.Proyecto
            };
            _context.paginas.Add(pagina);
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
            return _mapper.Map<PaginaDto>(pagina);
            
        }

     
    }
}

