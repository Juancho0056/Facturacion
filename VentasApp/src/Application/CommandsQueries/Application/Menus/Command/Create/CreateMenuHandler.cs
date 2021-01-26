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

namespace Application.CommandQueries.Menus.Command.Create
{
    public class CreateMenuHandler : CommandRequestHandler<CreateMenuRequest, ICollection<MenuDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CreateMenuHandler(IApplicationDbContext context, IMediator mediator, IMapper mapper) : base(context)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }
        public override async Task<ICollection<MenuDto>> HandleCommand(CreateMenuRequest request, CancellationToken cancellationToken)
        {
            var vm = new List<MenuDto>();
            ApplicationMenu menu = new ApplicationMenu
            {
                Titulo = request.Titulo,
                Nombre = request.Nombre,
                Url = request.Url,
                Padre = request.Padre,
                PaginaId = request.PaginaId
            };
            _context.menus.Add(menu);
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
            vm.Add(_mapper.Map<MenuDto>(menu));
            return vm;
        }

     
    }
}

