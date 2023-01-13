using System.ComponentModel.DataAnnotations;

namespace WebAppApi_1.Models.DTO
{
    public class ItemModelDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }
        public string? Description { get; set; }


    }
}
