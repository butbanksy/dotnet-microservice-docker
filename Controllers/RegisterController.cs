using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UsersMicroservice.DTO;
using UsersMicroservice.Models;
using UsersMicroservice.Services;

namespace UsersMicroservice.Controllers
{
    [Route("api/register")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public RegisterController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Register(UserRegisterDto userRegisterDto)
        {
            var user = _userService.RegisterUser(userRegisterDto);
            var registeredUser = _mapper.Map<UserRegisterSuccessfulDto>(user);
            registeredUser.RegistrationDate = DateTime.Now;
            return Ok(registeredUser);
        }
    }
}