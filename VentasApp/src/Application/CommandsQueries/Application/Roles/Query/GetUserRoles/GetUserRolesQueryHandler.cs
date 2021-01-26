using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities.Application;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Interfaces;
using VentasApp.Application.Common.Models;

namespace Application.Application.Roles.Query.GetUserRoles
{
    public class GetUserRolesHandler : QueryRequestHandler<GetUserRolesRequest, GetUserRolesResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        public GetUserRolesHandler(IApplicationDbContext context, IMapper mapper,
             UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }
        public override async Task<GetUserRolesResponse> HandleQuery(GetUserRolesRequest request, CancellationToken cancellationToken)
        {
            IQueryable<ApplicationRole> query = (from roles in _context.applicationroles
                                                 join userrole in _context.applicationuserroles on roles.Id equals userrole.RoleId
                                                 join users in _context.applicationusers on userrole.UserId equals users.Id
                                                 where users.UserName == request.Username
                                                 select roles
                                        );
            
            if (request.sort != null)
                query = request.sort.Length > 0 ? query = query.ApplySorting(request.sort) : query = query.OrderBy(c => c.Id);

            int count = query.Count();

            var pages = ((int)Math.Ceiling((double)count / request.Limit));
            var data = await query.AsNoTracking()
                            .Skip((request.Page - 1) * request.Limit)
                            .Take(request.Limit).ProjectTo<RoleDto>(_mapper.ConfigurationProvider)
                            .ToListAsync(cancellationToken);

            var vm = new GetUserRolesResponse
            {
                Data = data,
                Count = count,
                Pages = pages
            };

            return vm;

        }
    }
}
