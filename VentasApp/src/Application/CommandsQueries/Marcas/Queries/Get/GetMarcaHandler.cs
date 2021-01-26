using Application.CommandQueries.Marcas;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Interfaces;

namespace Application.CommandsQueries.Marcas.Queries.Get
{
    public class GetMarcaHandler : QueryRequestHandler<GetMarcaRequest, MarcaDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetMarcaHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<MarcaDto> HandleQuery(GetMarcaRequest request, CancellationToken cancellationToken)
        {
            var vm = await _context.marcas
                     .AsNoTracking()
                     .Where(e => e.Id == request.Id)
                     .ProjectTo<MarcaDto>(_mapper.ConfigurationProvider)
                     .SingleOrDefaultAsync(cancellationToken);

            return vm;

        }
    }
}
