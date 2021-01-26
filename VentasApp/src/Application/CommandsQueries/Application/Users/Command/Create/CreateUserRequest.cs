using Domain.Entities.Application;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Exceptions;
using VentasApp.Application.Common.Interfaces;

namespace Application.Application.Users.Command.Create
{
    public class CreateUserRequest : CommandRequest<ICollection<UserDto>>, IValidatableObject
    {
        [MinLength(5, ErrorMessage=ErrorMessage.MinLength+". 5")]
        [MaxLength(15, ErrorMessage = ErrorMessage.MinLength + ". 15")]
        public string Username { get; set; }
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [EmailAddress(ErrorMessage = ErrorMessage.IsEmail)]
        [MaxLength(255, ErrorMessage = ErrorMessage.MaxLength + " 255.")]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string IdentificationCard { get; set; }
        [Display(Name = "Primer Nombre")]
        [Required()]
        [MaxLength(80, ErrorMessage = ErrorMessage.MinLength + ". 80")]
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public bool EstadoRegistro { get; set; }
        public string Createdby { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errores = new List<ValidationResult>();
            var _context = (IApplicationDbContext)validationContext.GetService(typeof(IApplicationDbContext));
            var _utilService = (IUtilService)validationContext.GetService(typeof(IUtilService));
            //UserManager<ApplicationUser> _userManager
            var _userManager = (UserManager<ApplicationUser>)validationContext.GetService(typeof(UserManager<ApplicationUser>));
            try
            {
                var userFound = _userManager.Users.Where(x => x.UserName == Username).FirstOrDefault();
                
                if (userFound != null && userFound.IdentificationCard != IdentificationCard)
                {
                    errores.Add(new ValidationResult(ErrorMessage.Exist, new[] { "ApplicationUser" }));
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