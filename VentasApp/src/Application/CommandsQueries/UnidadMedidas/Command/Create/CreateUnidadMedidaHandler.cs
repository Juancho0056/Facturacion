using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Interfaces;

namespace Application.CommandQueries.UnidadMedidas.Command.Create
{
    public class CreateUnidadMedidaHandler : CommandRequestHandler<CreateUnidadMedidaRequest, ICollection<UnidadMedidaDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CreateUnidadMedidaHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper) : base(context)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }
        public override async Task<ICollection<UnidadMedidaDto>> HandleCommand(CreateUnidadMedidaRequest request, CancellationToken cancellationToken)
        {
            var vm = new List<UnidadMedidaDto>();
            UnidadMedida unidadmedida = new UnidadMedida
            {
                Detalle = request.Detalle
            };
            _context.unidadesmedidas.Add(unidadmedida);
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
            vm.Add(_mapper.Map<UnidadMedidaDto>(unidadmedida));
            return vm;
        }

     
    }
}

