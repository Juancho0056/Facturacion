using Application.CommandQueries.Grupos;
using Application.CommandQueries.Grupos.Command.Create;
using Application.CommandQueries.Grupos.Command.Delete;
using Application.CommandQueries.Grupos.Command.Update;
using Application.CommandsQueries.Grupos.Queries.Get;
using Application.CommandsQueries.Grupos.Queries.GetAll;
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
    public class GrupoController : ApiController
    {
        /// <summary>
        /// Add Grupo
        /// </summary>
        /// <remarks>
        /// Create new record for Grupo
        /// </remarks>
        /// <param name="command">Instance for CreateGrupoRequest</param>
        /// <returns></returns>
        // POST: api/Grupo/Create
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpPost("[action]")]
        public async Task<ActionResult> Create([FromBody] CreateGrupoRequest command)
        {
            return await base.Command<CreateGrupoRequest, ICollection<GrupoDto>>(command);
        }
        /// <summary>
        /// Update Grupo
        /// </summary>
        /// <remarks>
        /// Update a specific record for Grupo
        /// </remarks>
        /// <param name="command">Instance for UpdateGrupoRequest</param>
        /// <returns></returns>
        // POST: api/Grupo/Update
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpPatch("[action]")]
        public async Task<ActionResult> Update([FromBody] UpdateGrupoRequest command)
        {
            return await base.Command<UpdateGrupoRequest, ICollection<GrupoDto>>(command);
        }
        ///// <summary>
        ///// Delete Grupo
        ///// </summary>
        ///// <remarks>
        ///// Delete specific record for Grupo
        ///// </remarks>
        ///// <param name="command">Instance for DeleteGrupoRequest</param>
        ///// <returns></returns>
        //// POST: api/Grupo/Delete
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpDelete("[action]")]
        public async Task<ActionResult> Delete([FromBody] DeleteGrupoRequest command)
        {
            return await base.Command<DeleteGrupoRequest, ICollection<GrupoDto>>(command);
        }
        ///// <summary>
        ///// Get All Grupo
        ///// </summary>
        ///// <remarks>
        ///// Get all records for the Grupo filtered by the class paramater <code>GetAllGrupoRequest</code>
        ///// </remarks>
        ///// <param name="command">Instance for GetAllGrupoRequest</param>
        ///// <returns></returns>
        //// GET: api/Grupo/GetAll
        [ProducesResponseType(typeof(GrupoDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpGet("[action]")]
        public async Task<ActionResult> GetAll([FromQuery] GetAllGrupoRequest command)
        {
            return await base.Query<GetAllGrupoRequest, GetAllGrupoResponse>(command);
        }
        ///// <summary>
        ///// Get Grupo
        ///// </summary>
        ///// <remarks>
        ///// Get specific record for Grupo
        ///// </remarks>
        ///// <param name="command">Instance for GetAllGrupoRequest</param>
        ///// <returns></returns>
        //// GET: api/Grupo/Get
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpGet("[action]")]
        public async Task<ActionResult> Get([FromQuery] GetGrupoRequest command)
        {
            return await base.Query<GetGrupoRequest, GrupoDto>(command);
        }
    }
}
