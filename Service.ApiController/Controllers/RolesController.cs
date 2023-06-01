using Application.DTO.Request;
using Application.Interface;
using Infraestructure.Commons.Base.Request;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Autho.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRolesApplication _rolesApplication;

        public RolesController(IRolesApplication rolesApplication)
        {
            _rolesApplication = rolesApplication;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            //var response = await _usersPublicApplication.GetAsync(Id);
            var response = await _rolesApplication.RolesById(Id);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _rolesApplication.ListSelectRoles();
            return Ok(response);

        }

        [HttpPost]
        [Route("GetAllFilter")]
        public async Task<IActionResult> GetAllFilter([FromBody] BaseFiltersRequest request)
        {
            var response = await _rolesApplication.ListSelectRolesFilter(request);
            return Ok(response);

        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] RolesRequestCreateDto request)
        {
            string token = Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value;
            //var response = await _usersPublicApplication.CreateAsync(request, token);
            //return Ok(response);

            var response = await _rolesApplication.Register(request);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RolesRequestEditDto request)
        {
            string token = Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value;
            var response = await _rolesApplication.Edit(id, request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            string token = Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value;
            var response = await _rolesApplication.Remove(id);
            return Ok(response);
        }

    }
}
