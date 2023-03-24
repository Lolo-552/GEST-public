using System.ComponentModel.DataAnnotations;

namespace GEST.Models
{
    public class Publications
    {
        public int Id { get; set; }
        public string? Authors { get; set; }
        [Required(ErrorMessage = "Pole 'Autorzy' jest wymagane")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Pole 'Nazwa' jest wymagane")]
        public DateTime DateAdded { get; set; }
        public Publications()
        {
            DateAdded = DateTime.Now.Date;
        }
    }
}
