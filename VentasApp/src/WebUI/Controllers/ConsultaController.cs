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
using VentasApp.Application.CommandsQueries.Application.Consultas.Queries.GetAll;

namespace VentasApp.WebUI.Controllers
{
    public class ConsultaController : ApiController
    {
        
        [ProducesResponseType(typeof(MarcaDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpGet("[action]")]
        public async Task<ActionResult> GetAll([FromQuery] ConsultaRequest command)
        {
            return await base.Query<ConsultaRequest, ConsultaResponse>(command);
        }
       
    }
}
