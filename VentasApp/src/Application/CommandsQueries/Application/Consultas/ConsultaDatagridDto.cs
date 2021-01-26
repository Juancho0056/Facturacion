using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VentasApp.Application.Common.Mappings;
using VentasApp.Domain.Common;
using VentasApp.Domain.Entities.Application;

namespace VentasApp.Application.CommandsQueries.Application.Consultas
{
    public class ConsultaDatagridDto : AuditableEntity, IMapFrom<ConsultaDatagrid>
    {
        public ConsultaDatagridDto()
        {

        }
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Tabla { get; set; }
        public string SentenciaTable { get; set; }
        public string SentenciaCount { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ConsultaDatagrid, ConsultaDatagridDto>();
        }
    }
}
