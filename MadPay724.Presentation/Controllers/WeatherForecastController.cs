using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MadPay724.Data.DatabaseContext;
using MadPay724.Data.Dtos.Site.Admin;
using MadPay724.Data.Models;
using MadPay724.Repo.Infrastucturs;
using MadPay724.Services.Site.Admin.Auth.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
       

        private readonly IUnitOfWork<MadPayDbContext> _db;
        private readonly IAuthService _authservice;
        public WeatherForecastController(IUnitOfWork<MadPayDbContext> dbContext, IAuthService authservice)
        {
            _db = dbContext;
            _authservice = authservice;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            userForRegisterDto.UserName = userForRegisterDto.UserName.ToLower();
            if (await _db.UserRepository.UserExists(userForRegisterDto.UserName))
                return BadRequest("این نام کاریری وجود دارد");

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
    }
}
