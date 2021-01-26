using System.Threading.Tasks;

namespace VentasService.Util
{
    public interface BaseService<TData>
    {
        Task<TData> Get(string id, string authToken = null);
    }
}
