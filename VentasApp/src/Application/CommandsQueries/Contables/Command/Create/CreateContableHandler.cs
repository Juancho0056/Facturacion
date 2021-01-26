using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Interfaces;

namespace Application.CommandQueries.Contables.Command.Create
{
    public class CreateContableHandler : CommandRequestHandler<CreateContableRequest, ICollection<ContableDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CreateContableHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper) : base(context)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }
        public override async Task<ICollection<ContableDto>> HandleCommand(CreateContableRequest request, CancellationToken cancellationToken)
        {
            var vm = new List<ContableDto>();
            Contable contable = new Contable
            {
                Detalle = request.Detalle,
                IvaCompraId = request.IvaCompraId,
                IvaVentaId = request.IvaVentaId,
                ImpoConsumoId = request.ImpoConsumoId
            };
            _context.contables.Add(contable);
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
            vm.Add(_mapper.Map<ContableDto>(contable));
            return vm;
        }

     
    }
}

