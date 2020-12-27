using UsersMicroservice.DTO;
using UsersMicroservice.Models;

namespace UsersMicroservice.Services
{
    public interface IUserService
    {
        User AuthenticateUser(UserLoginDto userLoginDto);
        User RegisterUser(UserRegisterDto userRegisterDto);

        void Logout();
        UserTokenDto VerifyToken(string id);

        string GenerateJSONWebToken(User user);
    }
}