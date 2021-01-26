using Application.Application.Menus.Query.Get;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Interfaces;

namespace Application.Application.Users.Query.Get
{
    public class GetUserHandler : QueryRequestHandler<GetUserRequest, UserDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetUserHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<UserDto> HandleQuery(GetUserRequest request, CancellationToken cancellationToken)
        {
            var vm = await _context.applicationusers
                     .AsNoTracking()
                     .Where(e => e.Id == request.Id)
                     .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                     .SingleOrDefaultAsync(cancellationToken);

            return vm;

        }
    }
}
