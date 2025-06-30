using AuthorizationService.Models.DTO;
using AuthorizationService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationService.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService authService;

        public AuthController(AuthService authService) => this.authService = authService;

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            try 
            {
                var token = await authService.Register(dto);
                return Ok(new {Token = token });
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<IActionResult> Login(LoginDto dto)
        {
            try
            {
                var token = await authService.Login(dto);
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
