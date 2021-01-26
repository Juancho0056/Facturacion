using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Interfaces;

namespace Application.CommandQueries.Marcas.Command.Create
{
    public class CreateMarcaHandler : CommandRequestHandler<CreateMarcaRequest, ICollection<MarcaDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CreateMarcaHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper) : base(context)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }
        public override async Task<ICollection<MarcaDto>> HandleCommand(CreateMarcaRequest request, CancellationToken cancellationToken)
        {
            var vm = new List<MarcaDto>();
            Marca marca = new Marca
            {
                Detalle = request.Detalle
            };
            var sb = request.TipoCatalogo;
            _context.marcas.Add(marca);
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
            vm.Add(_mapper.Map<MarcaDto>(marca));
            return vm;
        }

     
    }
}

