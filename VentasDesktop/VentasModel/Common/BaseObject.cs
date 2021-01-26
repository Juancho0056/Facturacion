using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasModel.Entities.BaseEntities;

namespace VentasModel.Common
{
    public interface BaseObject<TData>
    {
        TData create(JObject jObject);

        TData create(TData jObject, List<BaseErrorDto> Errors, int ErrorCode);

    }
}
