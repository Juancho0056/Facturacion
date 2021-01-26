using Application.CommandQueries.UnidadMedidas;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Interfaces;

namespace Application.CommandsQueries.UnidadMedidas.Queries.Get
{
    public class GetUnidadMedidaHandler : QueryRequestHandler<GetUnidadMedidaRequest, UnidadMedidaDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetUnidadMedidaHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<UnidadMedidaDto> HandleQuery(GetUnidadMedidaRequest request, CancellationToken cancellationToken)
        {
            var vm = await _context.unidadesmedidas
                     .AsNoTracking()
                     .Where(e => e.Id == request.Id)
                     .ProjectTo<UnidadMedidaDto>(_mapper.ConfigurationProvider)
                     .SingleOrDefaultAsync(cancellationToken);

            return vm;

        }
    }
}
