using Application.DTO.Request;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAuthorizacion.Controllers {


    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [ApiController]
    public class MenuController : ControllerBase {
        private readonly IMenuApplication _menuApplication;

        public MenuController(IMenuApplication menuApplication)
        {
            _menuApplication = menuApplication;
        }

        [HttpGet("{Id}")]
        //[Route("list")]
        public async Task<IActionResult> Get(int Id) {
            //var response = await _usersPublicApplication.GetAsync(Id);
            var response = await _menuApplication.MenuById(Id);
            return Ok(response);

        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll() {
            var response = await _menuApplication.ListSelectMenu();
            return Ok(response);

        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] MenuRequestCreateDto request) {
            string token = Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value;
            //var response = await _usersPublicApplication.CreateAsync(request, token);
            //return Ok(response);

            var response = await _menuApplication.Register(request);
            return Ok(response);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MenuRequestEditDto request) {
            string token = Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value;
            var response = await _menuApplication.Edit(id, request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            string token = Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value;
            var response = await _menuApplication.Remove(id);
            return Ok(response);
        }
    }
}
