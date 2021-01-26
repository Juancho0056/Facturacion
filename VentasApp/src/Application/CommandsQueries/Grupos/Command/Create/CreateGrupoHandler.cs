using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Interfaces;

namespace Application.CommandQueries.Grupos.Command.Create
{
    public class CreateGrupoHandler : CommandRequestHandler<CreateGrupoRequest, ICollection<GrupoDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CreateGrupoHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper) : base(context)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }
        public override async Task<ICollection<GrupoDto>> HandleCommand(CreateGrupoRequest request, CancellationToken cancellationToken)
        {
            var vm = new List<GrupoDto>();
            Grupo grupo = new Grupo
            {
                Detalle = request.Detalle
            };
            _context.grupos.Add(grupo);
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
            vm.Add(_mapper.Map<GrupoDto>(grupo));
            return vm;
        }

     
    }
}

