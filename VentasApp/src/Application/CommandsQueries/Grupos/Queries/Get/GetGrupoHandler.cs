using Application.CommandQueries.Grupos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Interfaces;

namespace Application.CommandsQueries.Grupos.Queries.Get
{
    public class GetGrupoHandler : QueryRequestHandler<GetGrupoRequest, GrupoDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetGrupoHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<GrupoDto> HandleQuery(GetGrupoRequest request, CancellationToken cancellationToken)
        {
            var vm = await _context.grupos
                     .AsNoTracking()
                     .Where(e => e.Id == request.Id)
                     .ProjectTo<GrupoDto>(_mapper.ConfigurationProvider)
                     .SingleOrDefaultAsync(cancellationToken);

            return vm;

        }
    }
}
