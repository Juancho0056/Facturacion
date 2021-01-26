using System;
using System.Collections.Generic;
using System.Text;

namespace VentasApp.Application.CommandsQueries.Application.Consultas.Queries.GetAll
{
    public class ConsultaResponse
    {
        public dynamic Data { get; set; }
        public int Count { get; set; }
        public int Pages { get; set; }
    }
}
