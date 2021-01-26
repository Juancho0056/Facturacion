using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VentasApp.Application.Common.Abstracts;

namespace Application.Application.UserRoles.Command.Update
{
    public class UpdateUserRoleRequest : CommandRequest<ICollection<UserRoleDto>>, IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
