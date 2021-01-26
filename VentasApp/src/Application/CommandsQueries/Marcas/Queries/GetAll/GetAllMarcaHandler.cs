using Application.CommandQueries.Marcas;
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

namespace Application.CommandsQueries.Marcas.Queries.GetAll
{
    public class GetAllMarcaHandler : QueryRequestHandler<GetAllMarcaRequest, GetAllMarcaResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetAllMarcaHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<GetAllMarcaResponse> HandleQuery(GetAllMarcaRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Marca> query = (from v in _context.marcas
                                        orderby v.Detalle descending
                                        select v);
            if (request.Id > 0)
            {
                query = query.Where(v => v.Id.ToString().Contains(request.Id.ToString()));
            }
            if (!string.IsNullOrEmpty(request.Detalle))
            {
                query = query.Where(v => v.Detalle.ToLower().Contains(request.Detalle.ToLower()) );
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
                            .Take(request.Limit).ProjectTo<MarcaDto>(_mapper.ConfigurationProvider)
                            .ToListAsync(cancellationToken);

            var vm = new GetAllMarcaResponse
            {
                Data = data,
                Count = count,
                Pages = pages
            };

            return vm;

        }
    }
}
