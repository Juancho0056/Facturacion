using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Exceptions;

namespace VentasApp.Application.CommandsQueries.Application.Consultas.Queries.GetAll
{
    public class ConsultaRequest : QueryRequest<ConsultaResponse>
    {
        public int? Id { get; set; }
        [Required(ErrorMessage =ErrorMessage.IsRequired)]
        public string Tipo { get; set; }
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        public string Tabla { get; set; }
        public string Busqueda { get; set; }


    }
}
