using Application.CommandQueries.Menus;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VentasApp.Application.CommandsQueries.Application.Menus.Queries.GetMenuUsuario;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Interfaces;
using VentasApp.Domain.Entities.Application;

namespace Application.CommandsQueries.Menus.Queries.Get
{
    public class GetMenuUsuarioHandler : QueryRequestHandler<GetMenuUsuarioRequest, MenuUsuarioList>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetMenuUsuarioHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<MenuUsuarioList> HandleQuery(GetMenuUsuarioRequest request, CancellationToken cancellationToken)
        {
            IQueryable<ApplicationMenu> query = (from dtmenu in _context.menus.Include("Pagina")
                                      join dtpagina in _context.paginas on dtmenu.PaginaId equals dtpagina.Id into g
                                      from result in g.DefaultIfEmpty()
                                      join dtmenurol in _context.menusroles on dtmenu.Id equals dtmenurol.MenuId
                                      join dtrolusuario in _context.applicationuserroles on dtmenurol.RoleId equals dtrolusuario.RoleId
                                      join dtusuario in _context.applicationusers on dtrolusuario.UserId equals dtusuario.Id
                                      where dtusuario.UserName.ToLower().Equals(request.Username.ToLower())
                                      select dtmenu);
           
            if (request.Padre > 0)
            {
                query = query.Where(v => v.Padre == request.Padre);
            }
            else
            {
                query = query.Where(v => v.Padre == null);
            }
            var data = await query.AsNoTracking()
                    .ProjectTo<MenuDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
            var vm = new MenuUsuarioList
            {
                data = data
            };
            return vm;

        }
    }
}
