using System.ComponentModel.DataAnnotations;

namespace UsersMicroservice.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required] public string Username { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
    }
}