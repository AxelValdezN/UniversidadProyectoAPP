using System.ComponentModel.DataAnnotations;

namespace app_to_do.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Usuario { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
