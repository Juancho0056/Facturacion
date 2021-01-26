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
using VentasApp.Application.CommandsQueries.Application.Users.Query.GetAll;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Interfaces;
using VentasApp.Application.Common.Models;

namespace Application.Application.Users.Query.GetAll
{
    public class GetAllUserQueryHandler : QueryRequestHandler<GetAllUserRequest, GetAllUserResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetAllUserQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public override async Task<GetAllUserResponse> HandleQuery(GetAllUserRequest request, CancellationToken cancellationToken)
        {
            IQueryable<ApplicationUser> query = (from v in _context.applicationusers
                                                 orderby v.UserName descending
                                                 select v);

            if (!string.IsNullOrEmpty(request.FirstName))
            {
                query = query.Where(v => request.FirstName.ToLower().Contains(v.FirstName.ToLower()));
            }
            if (!string.IsNullOrEmpty(request.LastName))
            {
                query = query.Where(v => request.LastName.ToLower().Contains(v.LastName.ToLower()));
            }
            if (!string.IsNullOrEmpty(request.Email))
            {
                query = query.Where(v => request.Email.ToLower().Contains(v.Email.ToLower()));
            }
            if (!string.IsNullOrEmpty(request.IdentificationCard))
            {
                query = query.Where(v => request.IdentificationCard.ToLower().Contains(v.IdentificationCard.ToLower()));
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
                            .Take(request.Limit).ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                            .ToListAsync(cancellationToken);

            var vm = new GetAllUserResponse
            {
                Data = data,
                Count = count,
                Pages = pages
            };

            return vm;

        }
    }
}
