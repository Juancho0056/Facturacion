using Application.CommandQueries.Menus;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Interfaces;
using VentasApp.Application.Common.Models;
using VentasApp.Domain.Entities.Application;

namespace Application.CommandsQueries.Menus.Queries.GetAll
{
    public class GetAllMenuHandler : QueryRequestHandler<GetAllMenuRequest, GetAllMenuResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetAllMenuHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<GetAllMenuResponse> HandleQuery(GetAllMenuRequest request, CancellationToken cancellationToken)
        {
            IQueryable<ApplicationMenu> query = (from v in _context.menus
                                        orderby v.FechaCreacion descending
                                        select v);
            if (request.Id > 0)
            {
                query = query.Where(v => v.Id.ToString().Contains(request.Id.ToString()));
            }
            if (request.Padre > 0)
            {
                query = query.Where(v => v.Padre.ToString().Contains(request.Padre.ToString()));
            }
            if (!string.IsNullOrEmpty(request.Titulo))
            {
                query = query.Where(v => v.Titulo.ToLower().Contains(request.Titulo.ToLower()) );
            }
            if (!string.IsNullOrEmpty(request.Nombre))
            {
                query = query.Where(v => v.Nombre.ToLower().Contains(request.Nombre.ToLower()));
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
                            .Take(request.Limit).ProjectTo<MenuDto>(_mapper.ConfigurationProvider)
                            .ToListAsync(cancellationToken);

            var vm = new GetAllMenuResponse
            {
                Data = data,
                Count = count,
                Pages = pages
            };

            return vm;

        }
    }
}
