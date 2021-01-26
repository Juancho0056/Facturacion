using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using VentasModel.Entities.BaseEntities;

namespace VentasModel.Entities
{
    public class PaginaDto :   ErrorDto
    {
        
        public static PaginaDto create()
        {
            PaginaDto dto = new PaginaDto();
            return dto;
        }
        public static PaginaDto create(PaginaDto pagina, List<BaseErrorDto> Errors, int ErrorCode)
        {
            PaginaDto dto = new PaginaDto();
            dto.ErrorCode = ErrorCode;
            dto.Errors = Errors;
            dto.Id = pagina.Id;
            dto.Titulo = pagina.Titulo;
            dto.Nombre = pagina.Nombre;
            dto.Proyecto = pagina.Proyecto;
            dto.Url = pagina.Url;
            dto.EstadoRegistro = pagina.EstadoRegistro;
            dto.CreadoPor = pagina.CreadoPor;
            dto.FechaCreacion = pagina.FechaCreacion;
            dto.ModificadoPor = pagina.ModificadoPor;
            dto.FechaModificacion = pagina.FechaModificacion;
            return dto;
        }
        public static PaginaDto create(List<BaseErrorDto> Errors, int Error)
        {
            PaginaDto dto = new PaginaDto();
            dto.Errors = Errors;
            dto.ErrorCode = Error;
            return dto;
        }
        public static PaginaDto create(JObject objeto)
        {
            PaginaDto item = new PaginaDto();
            item.Id = Convert.ToInt32(objeto["id"].ToString());
            item.Titulo = objeto["titulo"].ToString();
            item.Nombre = objeto["nombre"].ToString();
            item.Proyecto = objeto["proyecto"].ToString();
            item.Url = objeto["url"].ToString();
            item.CreadoPor = objeto["creadoPor"].ToString();
            item.ModificadoPor = objeto["modificadoPor"].ToString();
            if (!string.IsNullOrEmpty(objeto["estadoRegistro"].ToString())) 
                item.EstadoRegistro = Convert.ToBoolean(objeto["estadoRegistro"]);
            if(objeto["fechaCreacion"].ToString() != null)
                item.FechaCreacion = Convert.ToDateTime(objeto["fechaCreacion"].ToString());

            if (!string.IsNullOrEmpty(objeto["fechaModificacion"].ToString()))
                item.FechaModificacion = Convert.ToDateTime(objeto["fechaModificacion"].ToString());

            if (!string.IsNullOrEmpty(objeto["fechaModificacion"].ToString()))
                item.FechaCreacion = Convert.ToDateTime(objeto["fechaModificacion"].ToString());


            return item;
        }

        public static PaginaDto create(int Id, string Nombre, string Titulo, string Proyecto, string Url)
        {
            PaginaDto item = new PaginaDto();
            item.Id = Id;
            item.Titulo = Titulo;
            item.Nombre = Nombre;
            item.Proyecto = Proyecto;
            item.Url = Url;
            return item;
        }
        public static PaginaDto create(int Id, string Nombre, string Titulo, string Proyecto, string Url, bool Estado)
        {
            PaginaDto item = new PaginaDto();
            item.Id = Id;
            item.Titulo = Titulo;
            item.Nombre = Nombre;
            item.Proyecto = Proyecto;
            item.Url = Url;
            item.EstadoRegistro = Estado;
            return item;
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Titulo { get; set; }
        public string Proyecto { get; set; }
        public string Url { get; set; }
        public bool EstadoRegistro { get; set; }
        public string CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}