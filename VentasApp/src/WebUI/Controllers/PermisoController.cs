using Application.CommandQueries.Permisos;
using Application.CommandQueries.Permisos.Command.Create;
using Application.CommandQueries.Permisos.Command.Delete;
using Application.CommandQueries.Permisos.Command.Update;
using Application.CommandsQueries.Permisos.Queries.Get;
using Application.CommandsQueries.Permisos.Queries.GetAll;
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
    public class PermisoController : ApiController
    {
        /// <summary>
        /// Add Permiso
        /// </summary>
        /// <remarks>
        /// Create new record for Permiso
        /// </remarks>
        /// <param name="command">Instance for CreatePermisoRequest</param>
        /// <returns></returns>
        // POST: api/Permiso/Create
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpPost("[action]")]
        public async Task<ActionResult> Create([FromBody] CreatePermisoRequest command)
        {
            return await base.Command<CreatePermisoRequest, ICollection<PermisoDto>>(command);
        }
        /// <summary>
        /// Update Permiso
        /// </summary>
        /// <remarks>
        /// Update a specific record for Permiso
        /// </remarks>
        /// <param name="command">Instance for UpdatePermisoRequest</param>
        /// <returns></returns>
        // POST: api/Permiso/Update
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpPatch("[action]")]
        public async Task<ActionResult> Update([FromBody] UpdatePermisoRequest command)
        {
            return await base.Command<UpdatePermisoRequest, ICollection<PermisoDto>>(command);
        }
        ///// <summary>
        ///// Delete Permiso
        ///// </summary>
        ///// <remarks>
        ///// Delete specific record for Permiso
        ///// </remarks>
        ///// <param name="command">Instance for DeletePermisoRequest</param>
        ///// <returns></returns>
        //// POST: api/Permiso/Delete
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpDelete("[action]")]
        public async Task<ActionResult> Delete([FromBody] DeletePermisoRequest command)
        {
            return await base.Command<DeletePermisoRequest, ICollection<PermisoDto>>(command);
        }
        ///// <summary>
        ///// Get All Permiso
        ///// </summary>
        ///// <remarks>
        ///// Get all records for the Permiso filtered by the class paramater <code>GetAllPermisoRequest</code>
        ///// </remarks>
        ///// <param name="command">Instance for GetAllPermisoRequest</param>
        ///// <returns></returns>
        //// GET: api/Permiso/GetAll
        [ProducesResponseType(typeof(PermisoDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpGet("[action]")]
        public async Task<ActionResult> GetAll([FromQuery] GetAllPermisoRequest command)
        {
            return await base.Query<GetAllPermisoRequest, GetAllPermisoResponse>(command);
        }
        ///// <summary>
        ///// Get Permiso
        ///// </summary>
        ///// <remarks>
        ///// Get specific record for Permiso
        ///// </remarks>
        ///// <param name="command">Instance for GetAllPermisoRequest</param>
        ///// <returns></returns>
        //// GET: api/Permiso/Get
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpGet("[action]")]
        public async Task<ActionResult> Get([FromQuery] GetPermisoRequest command)
        {
            return await base.Query<GetPermisoRequest, PermisoDto>(command);
        }
    }
}
