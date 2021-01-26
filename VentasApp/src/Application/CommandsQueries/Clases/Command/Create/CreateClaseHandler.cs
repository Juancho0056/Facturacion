using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Interfaces;

namespace Application.CommandQueries.Clases.Command.Create
{
    public class CreateClaseHandler : CommandRequestHandler<CreateClaseRequest, ICollection<ClaseDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CreateClaseHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper) : base(context)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }
        public override async Task<ICollection<ClaseDto>> HandleCommand(CreateClaseRequest request, CancellationToken cancellationToken)
        {
            var vm = new List<ClaseDto>();
            Clase clase = new Clase
            {
                Detalle = request.Detalle
            };
            _context.clases.Add(clase);
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
            vm.Add(_mapper.Map<ClaseDto>(clase));
            return vm;
        }

     
    }
}

