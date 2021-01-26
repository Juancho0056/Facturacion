namespace VentasModel.Entities.BaseEntities
{
    public class BaseErrorDto
    {
        public string Field { get; set; }
        public string Description { get; set; }

        public static BaseErrorDto create(string Field, object Description)
        {
            BaseErrorDto dto = new BaseErrorDto();
            foreach (var value in (object[])Description)
            {
                dto.Description = value.ToString();
            }
            dto.Field = Field;
            return dto;
        }
        public static BaseErrorDto create(string Field, string Description)
        {
            BaseErrorDto dto = new BaseErrorDto();
            dto.Description = Description;
            dto.Field = Field;
            return dto;
        }
    }
}