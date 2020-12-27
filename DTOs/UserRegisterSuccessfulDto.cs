using System;

namespace UsersMicroservice.DTO
{
    public class UserRegisterSuccessfulDto
    {
        public int Id { get; set; }
        public string Username
        { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}