using firstAPI_2023_04_19.Models;
using System.ComponentModel.DataAnnotations;

namespace firstAPI_2023_04_19.Dtos
{
    public class StaffPostDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        [StringLength(80)]
        public string? Address { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Phone length only be 10.")]
        public string? Phone { get; set; }
        [Required]
        [StringLength(20)]
        public string? Department { get; set; }
        [Required]
        public int? Salary { get; set; }

    }
}
