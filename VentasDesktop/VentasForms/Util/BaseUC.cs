using System.Threading.Tasks;
using System.Windows.Forms;

namespace VentasForms.Util
{
    public interface BaseUC
    {
        void LlenarCamposExterno(int id, FormMode mode);
        Task<dynamic> Get(int id);
        //Task<dynamic> GetPermission(string usuario, string pagina);

    }
}
