using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasService.Models.BaseModel.Error;

namespace VentasService.Models.BaseModel
{
    public class Response<TData>: AbstractResponse<TData>
    {
        public static Response<TData> create(int ErrorCode, List<BaseResponseDto> Errors, string jObject)
        {
            Response<TData> dto = new Response<TData>();
            dto.ErrorCode = ErrorCode;
            dto.Errors = Errors;
            dto.jObject = jObject;
            return dto;
        }

        public static Response<TData> create(int ErrorCode, List<BaseResponseDto> Errors)
        {
            Response<TData> dto = new Response<TData>();
            dto.ErrorCode = ErrorCode;
            dto.Errors = Errors;
            return dto;
        }
    }
}
