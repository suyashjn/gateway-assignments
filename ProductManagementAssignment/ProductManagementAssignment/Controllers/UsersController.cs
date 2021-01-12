using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u =>
                u.Email == model.Email && u.Password == model.Password);

            if (user != null)
                return Ok(new UserDto
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email
                });

            return Unauthorized(new {Error = "Invalid email or password"});
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);

            if (user != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new {error = "User already exists!"});

            await _context.Users.AddAsync(new AppUser
            {
                UserName = model.UserName,
                Email = model.Email,
                Password = model.Password,
                CreatedAt = DateTime.Now
            });
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status201Created, new {msg = "User created successfully"});
        }
    }
}