using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities.Application;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Interfaces;

namespace Application.Application.Users.Command.Login
{
    public class LoginUserCommandHandler : QueryRequestHandler<LoginUserRequest, LoginUserDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public LoginUserCommandHandler(IApplicationDbContext context, IMapper mapper,
            SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public override async Task<LoginUserDto> HandleQuery(LoginUserRequest request, CancellationToken cancellationToken)
        {
            var result = await _signInManager.PasswordSignInAsync(request.Username, request.Password, false, true);
            LoginUserDto vm = new LoginUserDto();
            if (result.Succeeded)
            {
                var users = _userManager.Users.Where(u => u.UserName == request.Username);
                var user = await users.FirstOrDefaultAsync(cancellationToken);
                user.Lastlogin = DateTime.Now;
                var save_user = await _userManager.UpdateAsync(user);
                if (save_user.Succeeded)
                {
                    vm = await users.ProjectTo<LoginUserDto>(_mapper.ConfigurationProvider).SingleOrDefaultAsync(cancellationToken);
                }

            }

            return vm;

        }
    }
}
