using System.ComponentModel.DataAnnotations;

namespace GEST.Models
{
    public class News : Article
    {
        [Required(ErrorMessage = "Pole 'Krótki opis' jest wymagane")]
        public string? ShortDescription { get; set; }
        [Required(ErrorMessage = "Pole 'Krótki opis' w języku angielskim jest wymagane")]
        public string? ShortDescription_en { get; set; }
        public DateTime DatePublished { get; set; }
    }
}
