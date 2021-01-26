using AutoMapper;
using Domain.Entities.Application;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Exceptions;
using VentasApp.Application.Common.Interfaces;

namespace Application.Application.Users.Command.Create
{
    public class CreateUserHandler : CommandRequestHandler<CreateUserRequest, ICollection<UserDto>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;
        private readonly IMediator _mediator;
        private readonly IUtilService _utilService;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public CreateUserHandler(UserManager<ApplicationUser> userManager, 
            ICurrentUserService currentUserService, IDateTime dateTime, IMediator mediator,
            IUtilService utilService, IMapper mapper, IApplicationDbContext context) : base(context)
        {
            _userManager = userManager;
            _currentUserService = currentUserService;
            _dateTime = dateTime;
            _mediator = mediator;
            _utilService = utilService;
            _mapper = mapper;
            _context = context;
        }

        public override async Task<ICollection<UserDto>> HandleCommand(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var vm = new List<UserDto>();
           var errores = new StringBuilder();
            ApplicationUser user = new ApplicationUser
            {
                UserName = request.Username,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                IdentificationCard = request.IdentificationCard,
                EstadoRegistro = request.EstadoRegistro,
                FechaCreacion = _dateTime.Now,
                CreadoPor = _currentUserService.UserId,
                EmailConfirmed = true
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            try
            {
                if (result.Succeeded == false)
                {
                    foreach (var failure in result.Errors)
                    {
                        errores.Append(failure.Code + " "+failure.Description);
                    }
                    throw new Exception(errores.ToString());
                }
                //await _context.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                
                return await HandleCommand(request, cancellationToken);
            }
            vm.Add(_mapper.Map<UserDto>(user));
            return vm;
        }


    }
}

