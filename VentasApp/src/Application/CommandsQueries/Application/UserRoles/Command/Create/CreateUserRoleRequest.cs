﻿using Application.Application.UserRoles;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Exceptions;
using VentasApp.Application.Common.Interfaces;

namespace Application.Application.UserRoles.Command.Create
{
    public class CreateUserRoleRequest : CommandRequest<ICollection<UserRoleDto>>, IValidatableObject
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errores = new List<ValidationResult>();
            var _context = (IApplicationDbContext)validationContext.GetService(typeof(IApplicationDbContext));

            try
            {
                
                var role =  _context.applicationroles.AsNoTracking().Where(x => x.Id == RoleId)
                    .FirstOrDefault();

                if (role == null)
                {
                    errores.Add(new ValidationResult(ErrorMessage.NotFound("ApplicationRole"), new[] { "ApplicationRole" }));
                    return errores;
                }
                
                
                var user = _context.applicationusers.AsNoTracking().Where(x => x.Id == UserId)
                    .FirstOrDefault();

                if (user == null)
                {
                    errores.Add(new ValidationResult(ErrorMessage.NotFound("ApplicationUser"), new[] { "ApplicationUser" }));
                    return errores;
                }

                var entity = _context.applicationuserroles.Where(x => x.UserId == UserId
                && x.RoleId == RoleId).FirstOrDefault();
                if (entity != null)
                {
                    errores.Add(new ValidationResult(ErrorMessage.Exist, new[] { "ApplicationUserRole" }));
                    return errores;
                }
                return errores;
            }
            catch (Exception e)
            {
                errores.Add(new ValidationResult(e.Message));
                return errores;
            }
        }
    }
}
