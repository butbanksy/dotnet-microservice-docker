using System.ComponentModel.DataAnnotations;

namespace UsersMicroservice.DTO
{
    public class UserRegisterDto
    {
        [Required] [MinLength(4)] public string Username { get; set; }
        [Required] [MinLength(6)] public string Password { get; set; }
    }
}