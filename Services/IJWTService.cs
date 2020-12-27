using UsersMicroservice.DTO;
using UsersMicroservice.Models;

namespace UsersMicroservice.Services
{
    public interface IJWTService
    {
        string GenerateJSONWebToken(User user);
    }
}