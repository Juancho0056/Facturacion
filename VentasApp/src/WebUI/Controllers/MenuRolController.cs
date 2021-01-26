
using Application.Application.MenuRoles;
using Application.Application.MenuRoles.Command.Create;
using Application.Application.MenuRoles.Command.Update;
using GESTION.API.Application.Application.MenuRoles.Command.Delete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VentasApp.WebUI.Controllers
{
    [Authorize]
    public class MenuRoleController : ApiController
    {
        /// <summary>
        /// Add MenuRole
        /// </summary>
        /// <remarks>
        /// Create new record for MenuRole
        /// </remarks>
        /// <param name="command">Instance for CreateMenuRoleRequest</param>
        /// <returns></returns>
        // POST: api/MenuRole/Create
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpPost("[action]")]
        public async Task<ActionResult> Create([FromBody] CreateMenuRoleRequest command)
        {
            return await base.Command<CreateMenuRoleRequest, ICollection<MenuRoleDto>>(command);
        }
        /// <summary>
        /// Update MenuRole
        /// </summary>
        /// <remarks>
        /// Update a specific record for MenuRole
        /// </remarks>
        /// <param name="command">Instance for UpdateMenuRoleRequest</param>
        /// <returns></returns>
        // POST: api/MenuRole/Update
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpPatch("[action]")]
        public async Task<ActionResult> Update([FromBody] UpdateMenuRoleRequest command)
        {
            return await base.Command<UpdateMenuRoleRequest, ICollection<MenuRoleDto>>(command);
        }
        ///// <summary>
        ///// Delete MenuRole
        ///// </summary>
        ///// <remarks>
        ///// Delete specific record for MenuRole
        ///// </remarks>
        ///// <param name="command">Instance for DeleteMenuRoleRequest</param>
        ///// <returns></returns>
        //// POST: api/MenuRole/Delete
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpDelete("[action]")]
        public async Task<ActionResult> Delete([FromBody] DeleteMenuRoleRequest command)
        {
            return await base.Command<DeleteMenuRoleRequest, ICollection<MenuRoleDto>>(command);
        }
       
    }
}
