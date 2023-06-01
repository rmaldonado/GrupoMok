using Application.DTO.Request;
using Application.Interface;

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Users.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [ApiController]
    public class CompanysController : ControllerBase
    {
        private readonly ICompanyApplication _companyApplication;

        public CompanysController(ICompanyApplication companyApplication)
        {
            _companyApplication = companyApplication;
        }

        [HttpGet(Name = "GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _companyApplication.ListSelectCompany();
            return Ok(response);
        }


        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _companyApplication.CompanyById(id);
            return Ok(response);
        }
        

        //[HttpPost("GetAllBy")]
        //public async Task<IActionResult> GetAllBy([FromBody] CompanyQueryRequest request)
        //{
        //    var response = await _companysPublicAplication.GetByAsync(request);
        //    return Ok(response);
        //}

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CompanyRequestCreateDto request)
        {
            var response = await _companyApplication.Register(request);
            return Ok(response);
        }
        //PUT Modificar
       [HttpPut]
        //[ResponseType(typeof(EstadoClasificacionRequestDto))]
        public async Task<IActionResult> Put(int id,[FromBody] CompanyRequestEditDto request)
        {
            if (request == null) return BadRequest();
            var response = await _companyApplication.Edit(id,request);

            return Ok(response);
        }

        //DELETE Eliminar
       [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _companyApplication.Remove(id);
            return Ok(response);
        }
    }
}
