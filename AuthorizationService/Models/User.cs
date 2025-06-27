using System.ComponentModel.DataAnnotations;

namespace AuthorizationService.Models
{
    public class User
    {
        public Guid id { get; set; } = Guid.NewGuid();

        [Required]
        public string Email { get; set; }

        [Required] 
        public string Password { get; set; }

        public string Role { get; set; } 
    }
}
