using System.ComponentModel.DataAnnotations;

namespace MotosAPI.Entities
{
    public class Motos
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string marca { get; set; }
        [Required]
        public string modelo { get; set; }
        [Required]
        public int cc { get; set; }
    }
}
