using Application.CommandQueries.Articulos;
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

namespace Application.CommandsQueries.Articulos.Queries.GetAll
{
    public class GetAllArticuloHandler : QueryRequestHandler<GetAllArticuloRequest, GetAllArticuloResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetAllArticuloHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<GetAllArticuloResponse> HandleQuery(GetAllArticuloRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Articulo> query = (from v in _context.articulos
                                        orderby v.FechaCreacion descending
                                        select v);
            
            if (!string.IsNullOrEmpty(request.Detalle))
            {
                query = query.Where(v => v.Detalle.ToLower().Contains(request.Detalle.ToLower()) );
            }
            if (!string.IsNullOrEmpty(request.Descripcion))
            {
                query = query.Where(v => v.Descripcion.ToLower().Contains(request.Descripcion.ToLower()));
            }
            if (!string.IsNullOrEmpty(request.Modelo))
            {
                query = query.Where(v => v.Modelo.ToLower().Contains(request.Modelo.ToLower()));
            }
            if (!string.IsNullOrEmpty(request.Referencia))
            {
                query = query.Where(v => v.Referencia.ToLower().Contains(request.Referencia.ToLower()));
            }
            if (!string.IsNullOrEmpty(request.Observacion))
            {
                query = query.Where(v => v.Observacion.ToLower().Contains(request.Observacion.ToLower()));
            }
            query = query.Where(v => v.TipoCatalogo == ((char)request.TipoCatalogo).ToString());
            
            if (request.ClaseId > 0)
            {
                query = query.Where(v => v.ClaseId == request.ClaseId);
            }
            if (request.ContableId > 0)
            {
                query = query.Where(v => v.ContableId == request.ContableId);
            }
            if (request.GrupoId > 0)
            {
                query = query.Where(v => v.GrupoId == request.GrupoId);
            }
            if (request.MarcaId > 0)
            {
                query = query.Where(v => v.MarcaId == request.MarcaId);
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
                            .Take(request.Limit).ProjectTo<ArticuloDto>(_mapper.ConfigurationProvider)
                            .ToListAsync(cancellationToken);

            var vm = new GetAllArticuloResponse
            {
                Data = data,
                Count = count,
                Pages = pages
            };

            return vm;

        }
    }
}
