using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities.Application;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VentasApp.Application.CommandsQueries.Application.Roles.Query.GetAll;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Interfaces;
using VentasApp.Application.Common.Models;

namespace Application.Application.Roles.Query.GetAll
{
    public class GetAllRoleHandler : QueryRequestHandler<GetAllRoleRequest, GetAllRoleResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetAllRoleHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<GetAllRoleResponse> HandleQuery(GetAllRoleRequest request, CancellationToken cancellationToken)
        {
            IQueryable<ApplicationRole> query = (from v in _context.applicationroles
                                        orderby v.Name descending
                                        select v);
                if (!string.IsNullOrEmpty(request.Name))
                {
                    query = query.Where(v => request.Name.ToLower().Contains(v.Name.ToLower()));
                }
                if (!string.IsNullOrEmpty(request.Description))
                {
                    query = query.Where(v => request.Description.ToLower().Contains(v.Description.ToLower()));
                }
                if (request.IsActive != null)
                {
                    query = query.Where(v => request.IsActive.Equals(v.EstadoRegistro));
                }

                if (request.sort != null)
                query = request.sort.Length > 0 ? query = query.ApplySorting(request.sort) : query = query.OrderBy(c => c.Id);

            int count = query.Count();

            var pages = ((int)Math.Ceiling((double)count / request.Limit));
            var data = await query.AsNoTracking()
                            .Skip((request.Page - 1) * request.Limit)
                            .Take(request.Limit).ProjectTo<RoleDto>(_mapper.ConfigurationProvider)
                            .ToListAsync(cancellationToken);

            var vm = new GetAllRoleResponse
            {
                Data = data,
                Count = count,
                Pages = pages
            };

            return vm;
        }
    }
}
