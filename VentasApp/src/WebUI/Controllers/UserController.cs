using Application.Application.Menus.Query.Get;
using Application.Application.Users;
using Application.Application.Users.Command.Create;
using Application.Application.Users.Command.Delete;
using Application.Application.Users.Command.Update;
using Application.Application.Users.Query.GetAll;
using Domain.Entities.Application;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using VentasApp.Application.CommandsQueries.Application.Users.Query.GetAll;

namespace VentasApp.WebUI.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
        /// <summary>
        /// Add ApplicationUSer
        /// </summary>
        /// <remarks>
        /// Create new record for ApplicationUser
        /// </remarks>
        /// <param name="command">Instance for CreateUserRequest</param>
        /// <returns></returns>
        // POST: api/User/Create
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpPost("[action]")]
        public async Task<ActionResult> Create([FromBody] CreateUserRequest command)
        {
            var user = new ApplicationUser
            {
                UserName = command.Username,
                Email = command.Email,
                FirstName = command.FirstName,
                LastName = command.LastName,
                PhoneNumber = command.PhoneNumber,
                IdentificationCard = command.IdentificationCard,
                EstadoRegistro = command.EstadoRegistro
            };
            await base.Command<CreateUserRequest, ICollection<UserDto>>(command);
            var emailSend = await EmailSender.SendEmailAsync(user.Email, user.FirstName,
                    "Bienvenido a VentasApp",
                     await UtilService.getHtmlBodyAccount(command.Username, command.Password));
            if (emailSend > 0)
            {
                return Ok("Se ha enviado un correo de confirmacion");
            }
            return BadRequest();
        }


        ///// <summary>
        ///// Get All ApplicationUser
        ///// </summary>
        ///// <remarks>
        ///// Get all records for the ApplicationUser filtered by the class paramater <code>GetAllUserRequest</code>
        ///// </remarks>
        ///// <param name="command">Instance for GetAllUserRequest</param>
        ///// <returns></returns>
        //// GET: api/User/GetAll
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpGet("[action]")]
        public async Task<ActionResult> GetAll([FromQuery] GetAllUserRequest command)
        {
            return await base.Query<GetAllUserRequest, GetAllUserResponse>(command);
        }
        ///// <summary>
        ///// Get ApplicationUser
        ///// </summary>
        ///// <remarks>
        ///// Get specific record for ApplicationUser
        ///// </remarks>
        ///// <param name="command">Instance for GetAllUserRequest</param>
        ///// <returns></returns>
        //// GET: api/User/Get
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpGet("[action]")]
        public async Task<ActionResult> Get([FromQuery] GetUserRequest command)
        {
            return await base.Query<GetUserRequest, UserDto>(command);
        }
    }
}