using System.ComponentModel.DataAnnotations;

namespace GEST.Models
{
    public class Management
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Pole 'Imię' jest wymagane.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Pole 'Nazwisko' jest wymagane.")]
        public string? SureName { get; set; }

        [Required(ErrorMessage = "Pole 'Stanowsiko' jest wymagane.")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Pole 'Stanowsiko' po angielsku jest wymagane.")]
        public string? Title_en { get; set; }
        public string? Description { get; set; }
        public string? Description_en { get; set; }
        public DateTime DateAdded { get; set; }
        [RegularExpression(@"^\+48\s\d{9}$", ErrorMessage = "Nieprawidłowy numer telefonu.")]
        public string? Phone { get; set; }
        [EmailAddress(ErrorMessage = "Nieprawidłowy adres e-mail.")]
        public string? Email { get; set; }
        public Management()
        {
            DateAdded = DateTime.Now.Date;
        }
    }
}
