using Application.CommandQueries.Contables;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Interfaces;

namespace Application.CommandsQueries.Contables.Queries.Get
{
    public class GetContableHandler : QueryRequestHandler<GetContableRequest, ContableDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetContableHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<ContableDto> HandleQuery(GetContableRequest request, CancellationToken cancellationToken)
        {
            var vm = await _context.contables
                     .AsNoTracking()
                     .Where(e => e.Id == request.Id)
                     .ProjectTo<ContableDto>(_mapper.ConfigurationProvider)
                     .SingleOrDefaultAsync(cancellationToken);

            return vm;

        }
    }
}
