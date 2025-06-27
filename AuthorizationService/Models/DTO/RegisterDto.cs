using System.ComponentModel.DataAnnotations;

namespace AuthorizationService.Models.DTO
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Email is required!")]
        [EmailAddress(ErrorMessage = "Inavalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        [MinLength(6, ErrorMessage = "Inavalid email format")]
        public string Password { get; set; }
      
        public string? Role { get; set; }


    }
}
