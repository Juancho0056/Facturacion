using Newtonsoft.Json.Linq;
using System;
using VentasModel.Common;

namespace VentasModel.Entities
{
    public class Menu : AuditableEntity
    {
        public static Menu create(JObject objeto)
        {
            Menu item = new Menu();
            item.Id = Convert.ToInt32(objeto["id"].ToString());
            item.Titulo = objeto["titulo"].ToString();
            item.Nombre = objeto["nombre"].ToString();
            item.Url = objeto["url"].ToString();
            if (!string.IsNullOrEmpty(objeto["padre"].ToString()))
                item.Padre = (int)objeto["padre"];
            
            if (!string.IsNullOrEmpty(objeto["paginaId"].ToString()))
                item.PaginaId = (int)objeto["paginaId"];
            item.Pagina = new PaginaDto();
            if (!string.IsNullOrEmpty(objeto["pagina"].ToString()))
                item.Pagina = PaginaDto.create((JObject)objeto["pagina"]);
            
            return item;
        }
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Nombre { get; set; }
        public string Url { get; set; }
        public Nullable<int> Padre { get; set; }
        public Nullable<int> PaginaId { get; set; }
        public virtual PaginaDto Pagina { get; set; }


    }
}
