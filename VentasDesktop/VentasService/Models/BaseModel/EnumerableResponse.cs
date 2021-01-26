using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasService.Models.BaseModel.Error;

namespace VentasService.Models.BaseModel
{
    public class EnumerableResponse<TData>: AbstractResponse<TData>
    {
        public int Count { get; set; }
        public int Pages { get; set; }
        public int Total { get; set; }

        public static EnumerableResponse<TData> create(int ErrorCode, List<BaseResponseDto> Errors, string jObject)
        {
            EnumerableResponse<TData> dto = new EnumerableResponse<TData>();
            dto.ErrorCode = ErrorCode;
            dto.Errors = Errors;
            dto.jObject = jObject;
            return dto;
        }

        public static EnumerableResponse<TData> create(int ErrorCode, List<BaseResponseDto> Errors)
        {
            EnumerableResponse<TData> dto = new EnumerableResponse<TData>();
            dto.ErrorCode = ErrorCode;
            dto.Errors = Errors;
            return dto;
        }
    }
}
