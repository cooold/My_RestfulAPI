using firstAPI_2023_04_19.VaildationAttributes;
using System.ComponentModel.DataAnnotations;

namespace firstAPI_2023_04_19.Dtos
{
    public class infoMessagePostDto
    {
        /// <summary>
        /// 由系統帶入員工ID
        /// </summary>
        [Required]
        public int StaffId { get; set; }
        [InfoMessageText]
        public string? Text { get; set; }
    }
}
