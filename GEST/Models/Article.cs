using System.ComponentModel.DataAnnotations;

namespace GEST.Models
{
    public class Article
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Pole 'Tytuł' jest wymagane")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Pole 'Tytuł' w języku angielskim jest wymagane")]
        public string? Title_en { get; set; }
        public string? Description { get; set; }
        public string? Description_en { get; set; }
        public List<Photos>? Photos { get; set; }
        public List<Files>? Files { get; set; }
        public DateTime DateAdded { get; set; }
        public Article()
        {
            DateAdded = DateTime.Now.Date;
        }
    }
}