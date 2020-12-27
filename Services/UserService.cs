using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using UsersMicroservice.Data;
using UsersMicroservice.DTO;
using UsersMicroservice.Exceptions;
using UsersMicroservice.Helpers;
using UsersMicroservice.Models;

namespace UsersMicroservice.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _config;
        private readonly UserContext _context;
        private readonly IMapper _mapper;

        private readonly IJWTService _jwtService;

        public UserService(IConfiguration config, UserContext context, IMapper mapper, IJWTService jWtService)
        {
            _config = config;
            _context = context;
            _mapper = mapper;
            _jwtService = jWtService;
        }

        public User AuthenticateUser(UserLoginDto userLoginDto)
        {

            var user = _context.Users.SingleOrDefault(x => x.Username == userLoginDto.Username);

            // check if the username exists
            if (user == null)
                return null;

            // check if the password is correct
            if (!PasswordHelpers.VerifyPasswordHash(userLoginDto.Password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;

        }

        public User RegisterUser(UserRegisterDto userRegisterDto)
        {

            if (_context.Users.Any(x => x.Username == userRegisterDto.Username))
                throw new AppException("Username \"" + userRegisterDto.Username + "\" is already taken");

            byte[] passwordHash, passwordSalt;
            PasswordHelpers.CreatePasswordHash(userRegisterDto.Password, out passwordHash, out passwordSalt);

            var user = _mapper.Map<User>(userRegisterDto);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public void Logout()
        {
            throw new System.NotImplementedException();
        }

        public UserTokenDto VerifyToken(string id)
        {
            var user = _context.Users.FirstOrDefault(user => user.Id == Int32.Parse(id));
            var userTokenDto = _mapper.Map<UserTokenDto>(user);
            return userTokenDto;
        }

        public string GenerateJSONWebToken(User user)
        {
            return _jwtService.GenerateJSONWebToken(user);
        }



    }

}