
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Exceptions;
using VentasApp.Application.Common.Interfaces;
using VentasApp.Domain.Enums;

namespace Application.CommandsQueries.Menus.Queries.GetAll
{
    public class GetAllMenuRequest : QueryRequest<GetAllMenuResponse>
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Nombre { get; set; }
        public int? Padre { get; set; }
        public bool? EstadoRegistro { get; set; }

       
    }
}
