using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using VentasService.Models.BaseModel.Error;

namespace VentasService.Models.BaseModel
{
    public abstract class AbstractResponse<TData>
    {
        public int ErrorCode { get; set; }
        public List<BaseResponseDto> Errors { get; set; }
        public string jObject { get; set; }
        public TData Data { get; set; }

        
    }
    
}
