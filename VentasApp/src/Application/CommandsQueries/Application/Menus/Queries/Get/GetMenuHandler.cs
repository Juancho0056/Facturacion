using Application.CommandQueries.Menus;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Interfaces;

namespace Application.CommandsQueries.Menus.Queries.Get
{
    public class GetMenuHandler : QueryRequestHandler<GetMenuRequest, MenuDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetMenuHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<MenuDto> HandleQuery(GetMenuRequest request, CancellationToken cancellationToken)
        {
            var vm = await _context.menus
                     .AsNoTracking()
                     .Where(e => e.Id == request.Id)
                     .ProjectTo<MenuDto>(_mapper.ConfigurationProvider)
                     .SingleOrDefaultAsync(cancellationToken);

            return vm;

        }
    }
}
