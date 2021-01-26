using Application.CommandQueries.Contables;
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

namespace Application.CommandsQueries.Contables.Queries.GetAll
{
    public class GetAllContableHandler : QueryRequestHandler<GetAllContableRequest, GetAllContableResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetAllContableHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<GetAllContableResponse> HandleQuery(GetAllContableRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Contable> query = (from v in _context.contables
                                        orderby v.Detalle descending
                                        select v);
            if (request.Id > 0)
            {
                query = query.Where(v => v.Id.ToString().Contains(request.Id.ToString()));
            }
            if (request.IvaCompraId > 0)
            {
                query = query.Where(v => v.IvaCompraId == request.IvaCompraId);
            }
            if (request.IvaVentaId > 0)
            {
                query = query.Where(v => v.IvaVentaId ==request.IvaVentaId);
            }
            if (request.ImpoConsumoId > 0)
            {
                query = query.Where(v => v.ImpoConsumoId == request.ImpoConsumoId);
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
                            .Take(request.Limit).ProjectTo<ContableDto>(_mapper.ConfigurationProvider)
                            .ToListAsync(cancellationToken);

            var vm = new GetAllContableResponse
            {
                Data = data,
                Count = count,
                Pages = pages
            };

            return vm;

        }
    }
}
