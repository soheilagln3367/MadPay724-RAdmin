using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MadPay724.Data.DatabaseContext;
using MadPay724.Data.Infrastucturs;
using MadPay724.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MadPay724.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        private readonly IUnitOfWork<MadPayDbContext> _db;
        public WeatherForecastController(IUnitOfWork<MadPayDbContext> dbContext)
        {
            _db = dbContext;
        }
       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            //var user = new User()
            //{
            //    Address = "",
            //    City = "",
            //    DateOfBirth = "",
            //    IsActive = true,
            //    Name = "",
            //    PasswordHash = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, },
            //    PasswordSalt = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, },

            //    PhonNumber = "",
            //    Status = true,
            //    UserName = ""
            //};
            //await _db.UserRepository.InsertAsync(user);
            //await _db.SaveAsync();
            //var model = await _db.UserRepository.GetAllAsync();


            return Ok("asdaf");
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public async Task<string> Post([FromBody] string vlaue)
        {
            return null;
        }
        [HttpPut ("{id}")]
        async Task<string> Put(int id, [FromBody] string vlaue)
        {
            return null;
        }
        [HttpDelete("{id}")]
        async Task<string> Delete(int id)
        {
            return null;
        }
    }
}
