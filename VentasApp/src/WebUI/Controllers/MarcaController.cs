using Application.CommandQueries.Marcas;
using Application.CommandQueries.Marcas.Command.Create;
using Application.CommandQueries.Marcas.Command.Delete;
using Application.CommandQueries.Marcas.Command.Update;
using Application.CommandsQueries.Marcas.Queries.Get;
using Application.CommandsQueries.Marcas.Queries.GetAll;
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
    public class MarcaController : ApiController
    {
        /// <summary>
        /// Add Marca
        /// </summary>
        /// <remarks>
        /// Create new record for Marca
        /// </remarks>
        /// <param name="command">Instance for CreateMarcaRequest</param>
        /// <returns></returns>
        // POST: api/Marca/Create
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpPost("[action]")]
        public async Task<ActionResult> Create([FromBody] CreateMarcaRequest command)
        {
            return await base.Command<CreateMarcaRequest, ICollection<MarcaDto>>(command);
        }
        /// <summary>
        /// Update Marca
        /// </summary>
        /// <remarks>
        /// Update a specific record for Marca
        /// </remarks>
        /// <param name="command">Instance for UpdateMarcaRequest</param>
        /// <returns></returns>
        // POST: api/Marca/Update
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpPatch("[action]")]
        public async Task<ActionResult> Update([FromBody] UpdateMarcaRequest command)
        {
            return await base.Command<UpdateMarcaRequest, ICollection<MarcaDto>>(command);
        }
        ///// <summary>
        ///// Delete Marca
        ///// </summary>
        ///// <remarks>
        ///// Delete specific record for Marca
        ///// </remarks>
        ///// <param name="command">Instance for DeleteMarcaRequest</param>
        ///// <returns></returns>
        //// POST: api/Marca/Delete
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpDelete("[action]")]
        public async Task<ActionResult> Delete([FromBody] DeleteMarcaRequest command)
        {
            return await base.Command<DeleteMarcaRequest, ICollection<MarcaDto>>(command);
        }
        ///// <summary>
        ///// Get All Marca
        ///// </summary>
        ///// <remarks>
        ///// Get all records for the Marca filtered by the class paramater <code>GetAllMarcaRequest</code>
        ///// </remarks>
        ///// <param name="command">Instance for GetAllMarcaRequest</param>
        ///// <returns></returns>
        //// GET: api/Marca/GetAll
        [ProducesResponseType(typeof(MarcaDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpGet("[action]")]
        public async Task<ActionResult> GetAll([FromQuery] GetAllMarcaRequest command)
        {
            return await base.Query<GetAllMarcaRequest, GetAllMarcaResponse>(command);
        }
        ///// <summary>
        ///// Get Marca
        ///// </summary>
        ///// <remarks>
        ///// Get specific record for Marca
        ///// </remarks>
        ///// <param name="command">Instance for GetAllMarcaRequest</param>
        ///// <returns></returns>
        //// GET: api/Marca/Get
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpGet("[action]")]
        public async Task<ActionResult> Get([FromQuery] GetMarcaRequest command)
        {
            return await base.Query<GetMarcaRequest, MarcaDto>(command);
        }
    }
}
