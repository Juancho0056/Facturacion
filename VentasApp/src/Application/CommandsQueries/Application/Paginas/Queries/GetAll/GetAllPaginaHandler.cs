using Application.CommandQueries.Paginas;
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

namespace Application.CommandsQueries.Paginas.Queries.GetAll
{
    public class GetAllPaginaHandler : QueryRequestHandler<GetAllPaginaRequest, GetAllPaginaResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetAllPaginaHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<GetAllPaginaResponse> HandleQuery(GetAllPaginaRequest request, CancellationToken cancellationToken)
        {
            IQueryable<ApplicationPagina> query = (from v in _context.paginas
                                        orderby v.FechaCreacion descending
                                        select v);
            int total = query.Count();
            if (request.Id > 0)
            {
                query = query.Where(v => v.Id.ToString().Contains(request.Id.ToString()));
            }
            if (!string.IsNullOrEmpty(request.Titulo))
            {
                query = query.Where(v => v.Titulo.ToLower().Contains(request.Titulo.ToLower()) );
            }
            if (!string.IsNullOrEmpty(request.Nombre))
            {
                query = query.Where(v => v.Nombre.ToLower().Contains(request.Nombre.ToLower()));
            }
            if (!string.IsNullOrEmpty(request.Proyecto))
            {
                query = query.Where(v => v.Proyecto.ToLower().Contains(request.Proyecto.ToLower()));
            }
            if (!string.IsNullOrEmpty(request.Url))
            {
                query = query.Where(v => v.Url.ToLower().Contains(request.Url.ToLower()));
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
                            .Take(request.Limit).ProjectTo<PaginaDto>(_mapper.ConfigurationProvider)
                            .ToListAsync(cancellationToken);

            var vm = new GetAllPaginaResponse
            {
                Data = data,
                Count = count,
                Pages = pages,
                Total = total
            };

            return vm;

        }
    }
}
