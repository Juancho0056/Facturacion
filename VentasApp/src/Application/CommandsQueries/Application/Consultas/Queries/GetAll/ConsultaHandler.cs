using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Interfaces;
using VentasApp.Application.Common.Models;
using VentasApp.Domain.Entities.Application;

namespace VentasApp.Application.CommandsQueries.Application.Consultas.Queries.GetAll
{
    public class ConsultaHandler : QueryRequestHandler<ConsultaRequest, ConsultaResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IReadOnlyRepository _repository;
        private readonly IMapper _mapper;
        public ConsultaHandler(IApplicationDbContext context, IMapper mapper, IReadOnlyRepository repository)
        {
            _context = context;
            _mapper = mapper;
            _repository = repository;
        }

        public override async Task<ConsultaResponse> HandleQuery(ConsultaRequest request, CancellationToken cancellationToken)
        {

            IQueryable<ConsultaDatagrid> query = (from v in _context.consultas
                                                 orderby v.FechaCreacion descending
                                                 select v);
            if (request.Id > 0)
            {
                query = query.Where(v => v.Id.ToString().Contains(request.Id.ToString()));
            }
            
            if (!string.IsNullOrEmpty(request.Tabla))
            {
                query = query.Where(v => v.Pagina.ToLower().Contains(request.Tabla.ToLower()));
            }
            if (!string.IsNullOrEmpty(request.Tipo))
            {
                query = query.Where(v => v.Tipo.ToLower().Contains(request.Tipo.ToLower()));
            }
            query = query.Where(v => v.EstadoRegistro == true);
            
            if (request.sort != null)
                query = request.sort.Length > 0 ? query = query.ApplySorting(request.sort) : query = query.OrderBy(c => c.Id);

            var data = await query.AsNoTracking()
                                  .ProjectTo<ConsultaDatagridDto>(_mapper.ConfigurationProvider)
                                  .FirstOrDefaultAsync(cancellationToken);

            if (data != null)
            {
                var querySelect = string.Format(data.SentenciaTable, request.Busqueda,
                    (request.Page - 1) * request.Limit, request.Limit);
                var queryCount = string.Format(data.SentenciaCount, request.Busqueda);
                var vmConsulta = _repository.Query(querySelect);

                var countResult = _repository.Query(queryCount).FirstOrDefault();
                var sb = countResult.count;
                var count = countResult.count == null?0:Convert.ToInt32(countResult.count);

                var pages = ((int)Math.Ceiling((double)count / request.Limit));

                var vm1 = new ConsultaResponse
                {
                    Data = vmConsulta,
                    Count = count,
                    Pages = pages
                };
                return vm1;
            }
            return null;
        }
    }
}
