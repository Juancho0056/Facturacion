
using Application.Application.Menus.Query.Get;
using Application.Application.Roles;
using CommandsQueries.Application.Roles.Command.Create;
using CommandsQueries.Application.Roles.Command.Delete;
using CommandsQueries.Application.Roles.Command.Update;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VentasApp.Application.CommandsQueries.Application.Roles.Query.GetAll;

namespace VentasApp.WebUI.Controllers
{
    [Authorize]
    public class RolController : ApiController
    {
        /// <summary>
        /// Add Rol
        /// </summary>
        /// <remarks>
        /// Create new record for Rol
        /// </remarks>
        /// <param name="command">Instance for CreateRolRequest</param>
        /// <returns></returns>
        // POST: api/Rol/Create
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpPost("[action]")]
        public async Task<ActionResult> Create([FromBody] CreateRoleRequest command)
        {
            return await base.Command<CreateRoleRequest, ICollection<RoleDto>>(command);
        }
        /// <summary>
        /// Update Rol
        /// </summary>
        /// <remarks>
        /// Update a specific record for Rol
        /// </remarks>
        /// <param name="command">Instance for UpdateRolRequest</param>
        /// <returns></returns>
        // POST: api/Rol/Update
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpPatch("[action]")]
        public async Task<ActionResult> Update([FromBody] UpdateRoleRequest command)
        {
            return await base.Command<UpdateRoleRequest, ICollection<RoleDto>>(command);
        }
        ///// <summary>
        ///// Delete Rol
        ///// </summary>
        ///// <remarks>
        ///// Delete specific record for Rol
        ///// </remarks>
        ///// <param name="command">Instance for DeleteRolRequest</param>
        ///// <returns></returns>
        //// POST: api/Rol/Delete
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpDelete("[action]")]
        public async Task<ActionResult> Delete([FromBody] DeleteRoleRequest command)
        {
            return await base.Command<DeleteRoleRequest, ICollection<RoleDto>>(command);
        }
        ///// <summary>
        ///// Get All Rol
        ///// </summary>
        ///// <remarks>
        ///// Get all records for the Rol filtered by the class paramater <code>GetAllRolRequest</code>
        ///// </remarks>
        ///// <param name="command">Instance for GetAllRolRequest</param>
        ///// <returns></returns>
        //// GET: api/Rol/GetAll
        [ProducesResponseType(typeof(RoleDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpGet("[action]")]
        public async Task<ActionResult> GetAll([FromQuery] GetAllRoleRequest command)
        {
            return await base.Query<GetAllRoleRequest, GetAllRoleResponse>(command);
        }
        ///// <summary>
        ///// Get Rol
        ///// </summary>
        ///// <remarks>
        ///// Get specific record for Rol
        ///// </remarks>
        ///// <param name="command">Instance for GetAllRolRequest</param>
        ///// <returns></returns>
        //// GET: api/Rol/Get
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpGet("[action]")]
        public async Task<ActionResult> Get([FromQuery] GetRoleRequest command)
        {
            return await base.Query<GetRoleRequest, RoleDto>(command);
        }
    }
}
