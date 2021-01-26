using Newtonsoft.Json.Linq;
using VentasModel.Common;

namespace VentasModel.Entities
{
    public class Rol : AuditableEntity
    {
        public static Rol create(JObject objeto)
        {
            Rol item = new Rol();
            item.Id = objeto["id"].ToString();
            item.Description = objeto["description"].ToString();
            item.Name = objeto["name"].ToString();
            item.NormalizedName = objeto["normalizedname"].ToString();

            return item;
        }
        public string Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
    }
}
