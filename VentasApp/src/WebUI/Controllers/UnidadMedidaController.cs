using Application.CommandQueries.UnidadMedidas;
using Application.CommandQueries.UnidadMedidas.Command.Create;
using Application.CommandQueries.UnidadMedidas.Command.Delete;
using Application.CommandQueries.UnidadMedidas.Command.Update;
using Application.CommandsQueries.UnidadMedidas.Queries.Get;
using Application.CommandsQueries.UnidadMedidas.Queries.GetAll;
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
    public class UnidadMedidaController : ApiController
    {
        /// <summary>
        /// Add UnidadMedida
        /// </summary>
        /// <remarks>
        /// Create new record for UnidadMedida
        /// </remarks>
        /// <param name="command">Instance for CreateUnidadMedidaRequest</param>
        /// <returns></returns>
        // POST: api/UnidadMedida/Create
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpPost("[action]")]
        public async Task<ActionResult> Create([FromBody] CreateUnidadMedidaRequest command)
        {
            return await base.Command<CreateUnidadMedidaRequest, ICollection<UnidadMedidaDto>>(command);
        }
        /// <summary>
        /// Update UnidadMedida
        /// </summary>
        /// <remarks>
        /// Update a specific record for UnidadMedida
        /// </remarks>
        /// <param name="command">Instance for UpdateUnidadMedidaRequest</param>
        /// <returns></returns>
        // POST: api/UnidadMedida/Update
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpPatch("[action]")]
        public async Task<ActionResult> Update([FromBody] UpdateUnidadMedidaRequest command)
        {
            return await base.Command<UpdateUnidadMedidaRequest, ICollection<UnidadMedidaDto>>(command);
        }
        ///// <summary>
        ///// Delete UnidadMedida
        ///// </summary>
        ///// <remarks>
        ///// Delete specific record for UnidadMedida
        ///// </remarks>
        ///// <param name="command">Instance for DeleteUnidadMedidaRequest</param>
        ///// <returns></returns>
        //// POST: api/UnidadMedida/Delete
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpDelete("[action]")]
        public async Task<ActionResult> Delete([FromBody] DeleteUnidadMedidaRequest command)
        {
            return await base.Command<DeleteUnidadMedidaRequest, ICollection<UnidadMedidaDto>>(command);
        }
        ///// <summary>
        ///// Get All UnidadMedida
        ///// </summary>
        ///// <remarks>
        ///// Get all records for the UnidadMedida filtered by the class paramater <code>GetAllUnidadMedidaRequest</code>
        ///// </remarks>
        ///// <param name="command">Instance for GetAllUnidadMedidaRequest</param>
        ///// <returns></returns>
        //// GET: api/UnidadMedida/GetAll
        [ProducesResponseType(typeof(UnidadMedidaDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpGet("[action]")]
        public async Task<ActionResult> GetAll([FromQuery] GetAllUnidadMedidaRequest command)
        {
            return await base.Query<GetAllUnidadMedidaRequest, GetAllUnidadMedidaResponse>(command);
        }
        ///// <summary>
        ///// Get UnidadMedida
        ///// </summary>
        ///// <remarks>
        ///// Get specific record for UnidadMedida
        ///// </remarks>
        ///// <param name="command">Instance for GetAllUnidadMedidaRequest</param>
        ///// <returns></returns>
        //// GET: api/UnidadMedida/Get
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpGet("[action]")]
        public async Task<ActionResult> Get([FromQuery] GetUnidadMedidaRequest command)
        {
            return await base.Query<GetUnidadMedidaRequest, UnidadMedidaDto>(command);
        }
    }
}
