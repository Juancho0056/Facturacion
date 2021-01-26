using Application.CommandQueries.Contables;
using Application.CommandQueries.Contables.Command.Create;
using Application.CommandQueries.Contables.Command.Delete;
using Application.CommandQueries.Contables.Command.Update;
using Application.CommandsQueries.Contables.Queries.Get;
using Application.CommandsQueries.Contables.Queries.GetAll;
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
    public class ContableController : ApiController
    {
        /// <summary>
        /// Add Contable
        /// </summary>
        /// <remarks>
        /// Create new record for Contable
        /// </remarks>
        /// <param name="command">Instance for CreateContableRequest</param>
        /// <returns></returns>
        // POST: api/Contable/Create
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpPost("[action]")]
        public async Task<ActionResult> Create([FromBody] CreateContableRequest command)
        {
            return await base.Command<CreateContableRequest, ICollection<ContableDto>>(command);
        }
        /// <summary>
        /// Update Contable
        /// </summary>
        /// <remarks>
        /// Update a specific record for Contable
        /// </remarks>
        /// <param name="command">Instance for UpdateContableRequest</param>
        /// <returns></returns>
        // POST: api/Contable/Update
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpPatch("[action]")]
        public async Task<ActionResult> Update([FromBody] UpdateContableRequest command)
        {
            return await base.Command<UpdateContableRequest, ICollection<ContableDto>>(command);
        }
        ///// <summary>
        ///// Delete Contable
        ///// </summary>
        ///// <remarks>
        ///// Delete specific record for Contable
        ///// </remarks>
        ///// <param name="command">Instance for DeleteContableRequest</param>
        ///// <returns></returns>
        //// POST: api/Contable/Delete
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpDelete("[action]")]
        public async Task<ActionResult> Delete([FromBody] DeleteContableRequest command)
        {
            return await base.Command<DeleteContableRequest, ICollection<ContableDto>>(command);
        }
        ///// <summary>
        ///// Get All Contable
        ///// </summary>
        ///// <remarks>
        ///// Get all records for the Contable filtered by the class paramater <code>GetAllContableRequest</code>
        ///// </remarks>
        ///// <param name="command">Instance for GetAllContableRequest</param>
        ///// <returns></returns>
        //// GET: api/Contable/GetAll
        [ProducesResponseType(typeof(ContableDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpGet("[action]")]
        public async Task<ActionResult> GetAll([FromQuery] GetAllContableRequest command)
        {
            return await base.Query<GetAllContableRequest, GetAllContableResponse>(command);
        }
        ///// <summary>
        ///// Get Contable
        ///// </summary>
        ///// <remarks>
        ///// Get specific record for Contable
        ///// </remarks>
        ///// <param name="command">Instance for GetAllContableRequest</param>
        ///// <returns></returns>
        //// GET: api/Contable/Get
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpGet("[action]")]
        public async Task<ActionResult> Get([FromQuery] GetContableRequest command)
        {
            return await base.Query<GetContableRequest, ContableDto>(command);
        }
    }
}
