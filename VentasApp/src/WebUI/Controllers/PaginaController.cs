using Application.CommandQueries.Paginas;
using Application.CommandQueries.Paginas.Command.Create;
using Application.CommandQueries.Paginas.Command.Delete;
using Application.CommandQueries.Paginas.Command.Update;
using Application.CommandsQueries.Paginas.Queries.Get;
using Application.CommandsQueries.Paginas.Queries.GetAll;
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
    public class PaginaController : ApiController
    {
        /// <summary>
        /// Add Pagina
        /// </summary>
        /// <remarks>
        /// Create new record for Pagina
        /// </remarks>
        /// <param name="command">Instance for CreatePaginaRequest</param>
        /// <returns></returns>
        // POST: api/Pagina/Create
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpPost("[action]")]
        public async Task<ActionResult> Create([FromBody] CreatePaginaRequest command)
        {
            return await base.Command<CreatePaginaRequest, PaginaDto>(command);
        }
        /// <summary>
        /// Update Pagina
        /// </summary>
        /// <remarks>
        /// Update a specific record for Pagina
        /// </remarks>
        /// <param name="command">Instance for UpdatePaginaRequest</param>
        /// <returns></returns>
        // POST: api/Pagina/Update
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpPatch("[action]")]
        public async Task<ActionResult> Update([FromBody] UpdatePaginaRequest command)
        {
            return await base.Command<UpdatePaginaRequest, PaginaDto>(command);
        }
        ///// <summary>
        ///// Delete Pagina
        ///// </summary>
        ///// <remarks>
        ///// Delete specific record for Pagina
        ///// </remarks>
        ///// <param name="command">Instance for DeletePaginaRequest</param>
        ///// <returns></returns>
        //// POST: api/Pagina/Delete
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpDelete("[action]")]
        public async Task<ActionResult> Delete([FromBody] DeletePaginaRequest command)
        {
            return await base.Command<DeletePaginaRequest, PaginaDto>(command);
        }
        ///// <summary>
        ///// Get All Pagina
        ///// </summary>
        ///// <remarks>
        ///// Get all records for the Pagina filtered by the class paramater <code>GetAllPaginaRequest</code>
        ///// </remarks>
        ///// <param name="command">Instance for GetAllPaginaRequest</param>
        ///// <returns></returns>
        //// GET: api/Pagina/GetAll
        [ProducesResponseType(typeof(PaginaDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpGet("[action]")]
        public async Task<ActionResult> GetAll([FromQuery] GetAllPaginaRequest command)
        {
            return await base.Query<GetAllPaginaRequest, GetAllPaginaResponse>(command);
        }
        ///// <summary>
        ///// Get Pagina
        ///// </summary>
        ///// <remarks>
        ///// Get specific record for Pagina
        ///// </remarks>
        ///// <param name="command">Instance for GetAllPaginaRequest</param>
        ///// <returns></returns>
        //// GET: api/Pagina/Get
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpGet("[action]")]
        public async Task<ActionResult> Get([FromQuery] GetPaginaRequest command)
        {
            return await base.Query<GetPaginaRequest, PaginaDto>(command);
        }
    }
}
