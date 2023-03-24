namespace GEST.Areas.Admin.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? ResetToken { get; set; }
    }
}
