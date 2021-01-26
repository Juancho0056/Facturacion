using Application.CommandQueries.Menus;
using Application.CommandQueries.Menus.Command.Create;
using Application.CommandQueries.Menus.Command.Delete;
using Application.CommandQueries.Menus.Command.Update;
using Application.CommandsQueries.Menus.Queries.Get;
using Application.CommandsQueries.Menus.Queries.GetAll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VentasApp.Application.CommandsQueries.Application.Menus.Queries.GetMenuUsuario;
using VentasApp.WebUI.Models;

namespace VentasApp.WebUI.Controllers
{
    [Authorize]
    public class MenuController : ApiController
    {
        /// <summary>
        /// Add Menu
        /// </summary>
        /// <remarks>
        /// Create new record for Menu
        /// </remarks>
        /// <param name="command">Instance for CreateMenuRequest</param>
        /// <returns></returns>
        // POST: api/Menu/Create
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpPost("[action]")]
        public async Task<ActionResult> Create([FromBody] CreateMenuRequest command)
        {
            return await base.Command<CreateMenuRequest, ICollection<MenuDto>>(command);
        }
        /// <summary>
        /// Update Menu
        /// </summary>
        /// <remarks>
        /// Update a specific record for Menu
        /// </remarks>
        /// <param name="command">Instance for UpdateMenuRequest</param>
        /// <returns></returns>
        // POST: api/Menu/Update
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpPatch("[action]")]
        public async Task<ActionResult> Update([FromBody] UpdateMenuRequest command)
        {
            return await base.Command<UpdateMenuRequest, ICollection<MenuDto>>(command);
        }
        ///// <summary>
        ///// Delete Menu
        ///// </summary>
        ///// <remarks>
        ///// Delete specific record for Menu
        ///// </remarks>
        ///// <param name="command">Instance for DeleteMenuRequest</param>
        ///// <returns></returns>
        //// POST: api/Menu/Delete
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpDelete("[action]")]
        public async Task<ActionResult> Delete([FromBody] DeleteMenuRequest command)
        {
            return await base.Command<DeleteMenuRequest, ICollection<MenuDto>>(command);
        }
        ///// <summary>
        ///// Get All Menu
        ///// </summary>
        ///// <remarks>
        ///// Get all records for the Menu filtered by the class paramater <code>GetAllMenuRequest</code>
        ///// </remarks>
        ///// <param name="command">Instance for GetAllMenuRequest</param>
        ///// <returns></returns>
        //// GET: api/Menu/GetAll
        [ProducesResponseType(typeof(MenuDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpGet("[action]")]
        public async Task<ActionResult> GetAll([FromQuery] GetAllMenuRequest command)
        {
            return await base.Query<GetAllMenuRequest, GetAllMenuResponse>(command);
        }
        ///// <summary>
        ///// Get Menu
        ///// </summary>
        ///// <remarks>
        ///// Get specific record for Menu
        ///// </remarks>
        ///// <param name="command">Instance for GetAllMenuRequest</param>
        ///// <returns></returns>
        //// GET: api/Menu/Get
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpGet("[action]")]
        public async Task<ActionResult> Get([FromQuery] GetMenuRequest command)
        {
            return await base.Query<GetMenuRequest, MenuDto>(command);
        }


        ///// <summary>
        ///// Get MenuUsuario
        ///// </summary>
        ///// <remarks>
        ///// Get specific record for MenuUsuario
        ///// </remarks>
        ///// <param name="command">Instance for GetMenuUsuarioRequest</param>
        ///// <returns></returns>
        //// GET: api/MenuUsuario/MenuUsuario
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpGet("[action]")]
        public async Task<ActionResult> MenuUsuario([FromQuery] GetMenuUsuarioModel command)
        {
            var request = new GetMenuUsuarioRequest()
            {
                Username = user.UserId,
                Padre = command.Padre
            };
            return await base.Query<GetMenuUsuarioRequest, MenuUsuarioList>(request);
        }
    }
}
