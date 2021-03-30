using HRM.ERP.Common.Models;
using HRM.ERP.WebAPI.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace HRM.ERP.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("UserLogin")]
        public IActionResult UserLogin([FromBody] UserLogin user)
        {
            var result = _authService.Authenticate(user.Email, user.Password);
            if (result == null)
            {
                return BadRequest(new { message = "Email or Password is incorrect" });
            }
            return Ok(result);
        }
    }
}
