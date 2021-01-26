using Application.CommandQueries.Clases;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Interfaces;

namespace Application.CommandsQueries.Clases.Queries.Get
{
    public class GetClaseHandler : QueryRequestHandler<GetClaseRequest, ClaseDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetClaseHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<ClaseDto> HandleQuery(GetClaseRequest request, CancellationToken cancellationToken)
        {
            var vm = await _context.clases
                     .AsNoTracking()
                     .Where(e => e.Id == request.Id)
                     .ProjectTo<ClaseDto>(_mapper.ConfigurationProvider)
                     .SingleOrDefaultAsync(cancellationToken);

            return vm;

        }
    }
}
