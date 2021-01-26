using Application.CommandQueries.Paginas;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Interfaces;

namespace Application.CommandsQueries.Paginas.Queries.Get
{
    public class GetPaginaHandler : QueryRequestHandler<GetPaginaRequest, PaginaDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetPaginaHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<PaginaDto> HandleQuery(GetPaginaRequest request, CancellationToken cancellationToken)
        {
            var vm = await _context.paginas
                     .AsNoTracking()
                     .Where(e => e.Id == request.Id)
                     .ProjectTo<PaginaDto>(_mapper.ConfigurationProvider)
                     .SingleOrDefaultAsync(cancellationToken);

            return vm;

        }
    }
}
