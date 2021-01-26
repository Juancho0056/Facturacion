using Application.CommandQueries.Permisos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Interfaces;
using VentasApp.Application.Common.Models;
using VentasApp.Domain.Entities.Application;

namespace Application.CommandsQueries.Permisos.Queries.GetAll
{
    public class GetAllPermisoHandler : QueryRequestHandler<GetAllPermisoRequest, GetAllPermisoResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetAllPermisoHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<GetAllPermisoResponse> HandleQuery(GetAllPermisoRequest request, CancellationToken cancellationToken)
        {
            IQueryable<ApplicationPermission> query = (from v in _context.permissions
                                        orderby v.FechaCreacion descending
                                        select v);
            if (request.Id > 0)
            {
                query = query.Where(v => v.Id.ToString().Contains(request.Id.ToString()));
            }
            if (!string.IsNullOrEmpty(request.Detalle))
            {
                query = query.Where(v => v.Detalle.ToLower().Contains(request.Detalle.ToLower()) );
            }
            if (!string.IsNullOrEmpty(request.Slug))
            {
                query = query.Where(v => v.Slug.ToLower().Contains(request.Slug.ToLower()));
            }
            if (request.MenuRoleId > 0)
            {
                query = query.Where(v => v.MenuRoleId == request.MenuRoleId);
            }
            if (request.EstadoRegistro != null)
            {
                query = query.Where(v => v.EstadoRegistro.Equals(request.EstadoRegistro));
            }
            if(request.sort != null)                         
                query = request.sort.Length > 0 ? query = query.ApplySorting(request.sort) : query = query.OrderBy(c => c.Id);
            
            int count = query.Count();

            var pages = ((int)Math.Ceiling((double)count / request.Limit));
            var data = await query.AsNoTracking()
                            .Skip((request.Page - 1) * request.Limit)
                            .Take(request.Limit).ProjectTo<PermisoDto>(_mapper.ConfigurationProvider)
                            .ToListAsync(cancellationToken);

            var vm = new GetAllPermisoResponse
            {
                Data = data,
                Count = count,
                Pages = pages
            };

            return vm;

        }
    }
}
