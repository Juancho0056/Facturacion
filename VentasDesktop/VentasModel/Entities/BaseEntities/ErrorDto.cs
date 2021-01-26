using System.Collections.Generic;
namespace VentasModel.Entities.BaseEntities
{
    public abstract class ErrorDto
    {
        public int ErrorCode { get; set; }
        public List<BaseErrorDto> Errors { get; set; }
    }
}