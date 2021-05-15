using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwtDemo.DataAccess;
using JwtDemo.DataAccess.Entities;
using JwtDemo.Domain.Abstraction;
using JwtDemo.DTO;
using JwtDemo.DTO.Result;
using JwtDemo.WebApi_Client.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JwtDemo.WebApi_Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IJwtTokenService _iJWTTokenService;
        public AccountController(ApplicationContext context,
                                 UserManager<User> userManager,
                                 IJwtTokenService iJWTTokenService,
                                 SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _iJWTTokenService = iJWTTokenService;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<ResultDTO> Register(UserRegisterDTO model)
        {
            if (!ModelState.IsValid)
            {
                return new ErrorResultDTO()
                {
                    StatusCode = 403,
                    Message = "Error",
                    Errors = CustomValidator.GetErrorsByModel(ModelState)
                };
            }

            var user = new User()
            {
                UserName = model.Email,
                Email = model.Email,
                PhoneNumber = model.Phone
            };

            var userInfo = new UserInfo
            {
                Address = model.Address,
                FullName = model.FullName,
                Id = user.Id
            };

            var identityResult = await _userManager.CreateAsync(user, model.Password);

            if (!identityResult.Succeeded)
            {
                return new ErrorResultDTO
                {
                    StatusCode = 500,
                    Message = "Registration Error",
                    Errors = CustomValidator.GetErrorsByIdentityResult(identityResult)
                };
            }

            var result = await _userManager.AddToRoleAsync(user, "User");
            _context.UserInfos.Add(userInfo);
            await _context.SaveChangesAsync();

            return new ResultDTO
            {
                StatusCode = 200,
                Message = "OK"
            };
        }

        [HttpPost("login")]
        public async Task<ResultDTO> Login(UserLoginDTO model)
        {
            if (!ModelState.IsValid)
            {
                return new ErrorResultDTO
                {
                    StatusCode = 500,
                    Message = "Login Error",
                    Errors = CustomValidator.GetErrorsByModel(ModelState)
                };

            }

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            if (!result.Succeeded)
            {
                return new ErrorResultDTO
                {
                    StatusCode = 402,
                    Message = "Login failed",
                    Errors = new List<string>
                    {
                        "Login or password error"
                    }
                };
            }
            else
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                await _signInManager.SignInAsync(user, false);

                return new SuccessResultDTO
                {
                    StatusCode = 200,
                    Message = "Ok",
                    Token = _iJWTTokenService.CreateToken(user)
                };
            }

        }

    }
}