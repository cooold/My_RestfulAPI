using firstAPI_2023_04_19.Models;

namespace firstAPI_2023_04_19.Dtos
{
    public class Staff_InfoMessagesDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Phone { get; set; }

        public string? Department { get; set; }

        public virtual ICollection<InfoMessage> InfoMessages { get; set; } = new List<InfoMessage>();
    }
}
