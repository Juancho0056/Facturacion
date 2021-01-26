using Application.CommandQueries.Clases;
using Application.CommandQueries.Clases.Command.Create;
using Application.CommandQueries.Clases.Command.Delete;
using Application.CommandQueries.Clases.Command.Update;
using Application.CommandsQueries.Clases.Queries.Get;
using Application.CommandsQueries.Clases.Queries.GetAll;
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
    public class ClaseController : ApiController
    {
        /// <summary>
        /// Add Clase
        /// </summary>
        /// <remarks>
        /// Create new record for Clase
        /// </remarks>
        /// <param name="command">Instance for CreateClaseRequest</param>
        /// <returns></returns>
        // POST: api/Clase/Create
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpPost("[action]")]
        public async Task<ActionResult> Create([FromBody] CreateClaseRequest command)
        {
            return await base.Command<CreateClaseRequest, ICollection<ClaseDto>>(command);
        }
        /// <summary>
        /// Update Clase
        /// </summary>
        /// <remarks>
        /// Update a specific record for Clase
        /// </remarks>
        /// <param name="command">Instance for UpdateClaseRequest</param>
        /// <returns></returns>
        // POST: api/Clase/Update
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpPatch("[action]")]
        public async Task<ActionResult> Update([FromBody] UpdateClaseRequest command)
        {
            return await base.Command<UpdateClaseRequest, ICollection<ClaseDto>>(command);
        }
        ///// <summary>
        ///// Delete Clase
        ///// </summary>
        ///// <remarks>
        ///// Delete specific record for Clase
        ///// </remarks>
        ///// <param name="command">Instance for DeleteClaseRequest</param>
        ///// <returns></returns>
        //// POST: api/Clase/Delete
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpDelete("[action]")]
        public async Task<ActionResult> Delete([FromBody] DeleteClaseRequest command)
        {
            return await base.Command<DeleteClaseRequest, ICollection<ClaseDto>>(command);
        }
        ///// <summary>
        ///// Get All Clase
        ///// </summary>
        ///// <remarks>
        ///// Get all records for the Clase filtered by the class paramater <code>GetAllClaseRequest</code>
        ///// </remarks>
        ///// <param name="command">Instance for GetAllClaseRequest</param>
        ///// <returns></returns>
        //// GET: api/Clase/GetAll
        [ProducesResponseType(typeof(ClaseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpGet("[action]")]
        public async Task<ActionResult> GetAll([FromQuery] GetAllClaseRequest command)
        {
            return await base.Query<GetAllClaseRequest, GetAllClaseResponse>(command);
        }
        ///// <summary>
        ///// Get Clase
        ///// </summary>
        ///// <remarks>
        ///// Get specific record for Clase
        ///// </remarks>
        ///// <param name="command">Instance for GetAllClaseRequest</param>
        ///// <returns></returns>
        //// GET: api/Clase/Get
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpGet("[action]")]
        public async Task<ActionResult> Get([FromQuery] GetClaseRequest command)
        {
            return await base.Query<GetClaseRequest, ClaseDto>(command);
        }
    }
}
