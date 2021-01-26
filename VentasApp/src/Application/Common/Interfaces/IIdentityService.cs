using VentasApp.Application.Common.Models;
using System.Threading.Tasks;

namespace VentasApp.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(string userId);

    }
}
