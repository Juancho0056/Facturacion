using System;
using System.Collections.Generic;
using System.Text;
using VentasApp.Domain.Common;

namespace VentasApp.Application.Common.Interfaces
{
    public interface IMvcControllerDiscovery
    {
        IEnumerable<MvcControllerInfo> GetControllers();
    }
}
