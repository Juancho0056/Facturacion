using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasModel.Common;
using VentasModel.Entities.BaseEntities;

namespace VentasModel.Entities
{
    public class PermisosDto : AuditableEntity
    {
        public static PermisosDto create(JObject objeto)
        {
            PermisosDto item = new PermisosDto();
            item.Id = Convert.ToInt32(objeto["id"].ToString());
            item.Detalle = objeto["detalle"].ToString();
            item.Slug = objeto["slug"].ToString();
            item.CreadoPor = objeto["creadoPor"].ToString();
            item.ModificadoPor = objeto["modificadoPor"].ToString();
            if (!string.IsNullOrEmpty(objeto["estadoRegistro"].ToString()))
                item.EstadoRegistro = Convert.ToBoolean(objeto["estadoRegistro"]);
            if (objeto["fechaCreacion"].ToString() != null)
                item.FechaCreacion = Convert.ToDateTime(objeto["fechaCreacion"].ToString());

            if (!string.IsNullOrEmpty(objeto["fechaModificacion"].ToString()))
                item.FechaModificacion = Convert.ToDateTime(objeto["fechaModificacion"].ToString());

            if (!string.IsNullOrEmpty(objeto["fechaModificacion"].ToString()))
                item.FechaCreacion = Convert.ToDateTime(objeto["fechaModificacion"].ToString());
            return item;
        }
        public int Id { get; set; }
        public string Detalle { get; set; }
        public string Slug { get; set; }
        public int MenuRoleId { get; set; }
    }
}
