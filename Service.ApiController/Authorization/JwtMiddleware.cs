using Application.DTO.Request;
using Application.Interface;
using Application.Main.Extention;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;

namespace Service.ApiController.Authorization
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUserApplication userService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            ValidateJWT validateJwt = new ValidateJWT();
            var userId = validateJwt.Validate(token);

            if (userId != null)
            {
                // attach user to context on successful jwt validation
                context.Items["User"] = userService.UserById(1);
            }

            await _next(context);
        }
    }
}
