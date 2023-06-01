
using ApiAuthorizacion.Helpers;
using Application.DTO;
using Application.DTO.Request;
using Application.Interface;
using Infraestructure.Commons.Base.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransversalCommon.Interfaces;

namespace Users.Controllers
{

    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserApplication _userApplication;
        //private readonly IGenereteToken _genereteToken;
        //private readonly ITokenValidationDomain _tokenValidation;
        private readonly IAppLogger _appLogger;

        public UsersController(IUserApplication userApplication, 
            //ITokenValidationDomain tokenValidation , 
            IAppLogger appLogger)
        {
            _userApplication = userApplication;
            //_genereteToken = genereteToken;
           // _tokenValidation = tokenValidation;
            _appLogger = appLogger;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            //var response = await _usersPublicApplication.GetAsync(Id);
            var response = await _userApplication.UserById(Id);
            return StatusCode(response.StatusCode, response);

        }

        [Route("GetAll")]
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
           
            List<DataItem> listHeader = new List<DataItem>();
            listHeader.Add(new DataItem { Name = "token", Value = Header.GetToken(Request.Headers).Result });

            RequestGenerateTokenDto request = new();

            //_appLogger.LogInfo($"|ApiAuthorizacion|Begin request: {JsonConvert.SerializeObject(request)}");

            var response = await _userApplication.ListSelectUsers(request,listHeader);

            return StatusCode(response.StatusCode, response);
            //_appLogger.LogInfo($"|ApiAuthorizacion|Begin response: {JsonConvert.SerializeObject(response)}");

        }

        [Route("GetAllFilters")]
        [HttpGet]
        public async Task<IActionResult> GetAllFilters([FromQuery] BaseFiltersRequest filtersRequest)
        {

            List<DataItem> listHeader = new List<DataItem>();
            listHeader.Add(new DataItem { Name = "token", Value = Header.GetToken(Request.Headers).Result });

            var response = await _userApplication.ListUsersFilters(filtersRequest, listHeader);
            return StatusCode(response.StatusCode, response);

        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserRequestCreate request)
        {
            var response = await _userApplication.Register(request);
            return StatusCode(response.StatusCode, response);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,[FromBody] UserRequestEdit request)
        {
            string token = Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value;
            var response = await _userApplication.Edit(id,request);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            string token = Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value;
            var response = await _userApplication.Remove(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}