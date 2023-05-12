using firstAPI_2023_04_19.VaildationAttributes;

namespace firstAPI_2023_04_19.Dtos
{
    public class infoMessagePutDto
    {
        public int Id { get; set; }
        [InfoMessageText]
        public string? Text { get; set; }
    }
}
