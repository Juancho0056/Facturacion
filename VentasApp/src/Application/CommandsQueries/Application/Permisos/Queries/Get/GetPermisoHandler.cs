using Application.CommandQueries.Permisos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Interfaces;

namespace Application.CommandsQueries.Permisos.Queries.Get
{
    public class GetPermisoHandler : QueryRequestHandler<GetPermisoRequest, PermisoDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetPermisoHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<PermisoDto> HandleQuery(GetPermisoRequest request, CancellationToken cancellationToken)
        {
            var vm = await _context.permissions
                     .AsNoTracking()
                     .Where(e => e.Id == request.Id)
                     .ProjectTo<PermisoDto>(_mapper.ConfigurationProvider)
                     .SingleOrDefaultAsync(cancellationToken);

            return vm;

        }
    }
}
