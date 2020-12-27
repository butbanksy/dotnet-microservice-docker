using System.ComponentModel.DataAnnotations;

namespace UsersMicroservice.DTO
{
    
    public class UserLoginDto
    {
        [Required] public string Username { get; set; }
        [Required] public string Password { get; set; }

    }
}