namespace VentasService.Models.BaseModel.Error
{
    public class BaseResponseDto
    {
        public string Field { get; set; }
        public string Description { get; set; }

        public static BaseResponseDto create(string Field, object Description)
        {
            BaseResponseDto dto = new BaseResponseDto();
            foreach (var value in (object[])Description)
            {
                dto.Description = value.ToString();
            }
            dto.Field = Field;
            return dto;
        }
        public static BaseResponseDto create(string Field, string Description)
        {
            BaseResponseDto dto = new BaseResponseDto();
            dto.Description = Description;
            dto.Field = Field;
            return dto;
        }
    }
}