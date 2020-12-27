using System;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using UsersMicroservice.DTO;
using UsersMicroservice.Models;
using UsersMicroservice.Services;

namespace UsersMicroservice.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public LoginController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;

        }

        [HttpPost]
        public IActionResult Login(UserLoginDto userLoginDto)
        {
            var user = _userService.AuthenticateUser(userLoginDto);

            if (user == null)
            {
                return Unauthorized("The username/password is incorrect");
            }

            var tokenString = _userService.GenerateJSONWebToken(user);

            var authenticatedUser = _mapper.Map<UserLoginSuccessfulDto>(user);
            authenticatedUser.Token = tokenString;

            return Ok(authenticatedUser);
        }

        [Authorize]
        [HttpGet]
        [Route("/api/token")]
        public IActionResult VerifyToken()
        {
            var userId = User.FindFirst("sub")?.Value;
            var user = _userService.VerifyToken(userId);


            return Ok(user);

        }
    }
}