using Application.DTO.Request;
using Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace Users.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserApplication _userApplication;
        public AuthController(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto requestDto)
        {
            var loginResult = await _userApplication.AccountByUserName(requestDto);
           
            return StatusCode(loginResult.StatusCode, loginResult);
        }

        [AllowAnonymous]
        [Route("Validate")]
        [HttpPost]
        public async Task<IActionResult> Validate(RequestValidateDto requestValidateDto)
        {
            if (requestValidateDto == null) return BadRequest();
            var response = await _userApplication.ValidateToken(requestValidateDto);
            if (response.Message.Equals("Ok")) return Ok(response);
            return StatusCode(StatusCodes.Status500InternalServerError, response);

        }
    }
}
