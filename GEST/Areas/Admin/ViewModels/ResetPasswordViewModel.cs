using System.ComponentModel.DataAnnotations;

namespace GEST.Areas.Admin.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Required]
        public string Token { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }

}
