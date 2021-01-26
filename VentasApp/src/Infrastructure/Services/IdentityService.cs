using Domain.Entities.Application;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasApp.Application.Common.Interfaces;
using VentasApp.Application.Common.Models;

namespace VentasApp.Infrastructure.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IdentityService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> GetUserNameAsync(string userId)
        {
            //var user = await _userManager.Users.FirstAsync(x => x.UserName == userId);
            var user = await _userManager.Users.FirstAsync(x => x.UserName == userId);
            return user.UserName;
        }

    }
}
