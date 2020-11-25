using MadPay724.Comman.ErrorAndMessages;
using MadPay724.Data.DatabaseContext;
using MadPay724.Data.Dtos.Site.Admin;
using MadPay724.Data.Models;
using MadPay724.Repo.Infrastucturs;
using MadPay724.Services.Site.Admin.Auth.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace MadPay724.Presentation.Controllers.Site.Admin
{
    [Authorize]
    [Route("site/admin/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork<MadPayDbContext> _db;
        private readonly IAuthService _authservice;
        private readonly IConfiguration _configuration;
        public AuthController(IUnitOfWork<MadPayDbContext> dbContext, IAuthService authservice, IConfiguration configuration)
        {
            _db = dbContext;
            _authservice = authservice;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            userForRegisterDto.UserName = userForRegisterDto.UserName.ToLower();
            if (await _db.UserRepository.UserExists(userForRegisterDto.UserName))
                return BadRequest(new ReturnMessage()
                {
                    status = false,
                    title = "خطا",
                    message = "این نام کاربری وجود دارد"
                });
            ;

            var UserToCreat = new User
            {
                UserName = userForRegisterDto.UserName,
                Name = userForRegisterDto.Name,
                PhonNumber = userForRegisterDto.PhonNumber,
                Address = "",
                City = "",
                Gender = true,
                DateOfBirth = DateTime.Now,
                IsActive = true,
                Status = true,
            };
            var CreatUser = await _authservice.Register(UserToCreat, userForRegisterDto.Password);

            return StatusCode(201);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var userForRepo = await _authservice.Login(userForLoginDto.UserName, userForLoginDto.Password);
            if (userForRepo == null)
                return Unauthorized(new ReturnMessage()
                {
                    status = false,
                    title = "خطا",
                    message = "نام کاربری یا پسورد اشتباه می باشد"
                });
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userForRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userForRepo.Name)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDes = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = userForLoginDto.IsRemember ? DateTime.Now.AddDays(1) : DateTime.Now.AddHours(2),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDes);
            return Ok(new
            {
                token=tokenHandler.WriteToken(token)
            });
        }

        [AllowAnonymous]
        [HttpGet("value")]
        public async Task<IActionResult> GetValue()
        {
            return Ok(new ReturnMessage()
            {
                status = true,
                title = "ok",
                message = ""
            });
        }
        [HttpGet("values")]
        public async Task<IActionResult> GetValues()
        {
            return Ok(new ReturnMessage()
            {
                status = true,
                title = "ok",
                message = ""
            });
        }

    }

}
