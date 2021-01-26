﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using VentasApp.Application.Common.Interfaces;
using VentasApp.Domain.Common;

namespace VentasApp.WebUI.Filters
{
    public class DynamicAuthorizationFilter : IAsyncAuthorizationFilter
    {
        private readonly IApplicationDbContext _dbContext;

        public DynamicAuthorizationFilter(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (!IsProtectedAction(context))
                return;

            if (!IsUserAuthenticated(context))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var actionId = GetActionId(context);
            var userName = context.HttpContext.User?.FindFirstValue("Username");


            var roles = await (
                from user in _dbContext.applicationusers
                join userRole in _dbContext.applicationuserroles on user.Id equals userRole.UserId
                join role in _dbContext.applicationroles on userRole.RoleId equals role.Id
                where user.UserName == userName
                select role
            ).ToListAsync();

            foreach (var role in roles)
            {
                if (role.Access is null)
                    continue;
                var accessList =
                    JsonConvert.DeserializeObject<IEnumerable<MvcControllerInfo>>(role.Access);
                if (accessList.SelectMany(c => c.Actions).Any(a => a.Id == actionId))
                    return;
            }
            context.Result = new ForbidResult();
        }

        private bool IsProtectedAction(AuthorizationFilterContext context)
        {
            if (context.Filters.Any(item => item is IAllowAnonymousFilter))
                return false;

            var controllerActionDescriptor = (ControllerActionDescriptor)context.ActionDescriptor;
            var controllerTypeInfo = controllerActionDescriptor.ControllerTypeInfo;
            var actionMethodInfo = controllerActionDescriptor.MethodInfo;

            var authorizeAttribute = controllerTypeInfo.GetCustomAttribute<AuthorizeAttribute>();
            if (authorizeAttribute != null)
                return true;

            authorizeAttribute = actionMethodInfo.GetCustomAttribute<AuthorizeAttribute>();
            if (authorizeAttribute != null)
                return true;

            return false;
        }

        private bool IsUserAuthenticated(AuthorizationFilterContext context)
        {
            return context.HttpContext.User.Identity.IsAuthenticated;
        }

        private string GetActionId(AuthorizationFilterContext context)
        {
            var controllerActionDescriptor = (ControllerActionDescriptor)context.ActionDescriptor;
            var area = controllerActionDescriptor.ControllerTypeInfo.
                                 GetCustomAttribute<AreaAttribute>()?.RouteValue;
            var controller = controllerActionDescriptor.ControllerName;
            var action = controllerActionDescriptor.ActionName;

            return $"{area}:{controller}:{action}";
        }
    }
}

