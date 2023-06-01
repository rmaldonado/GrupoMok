using Application.DTO;
using Application.DTO.Base;
using Application.DTO.Request;
using Application.DTO.Response;
using Application.Interface;
using Application.Main.Extention;
using AutoMapper;
using Common;
using Domain.Core;
using Domain.Entity;
using Domain.Entity.V1;
using Domain.Interface;
using Domain.Interface.ValidationInterface.User;
using Infraestructure.Commons.Base.Request;
using Infraestructure.Commons.Base.Response;
using Infraestructure.Interface.Patterns;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransversalCommon.Interfaces;

namespace Application.Main
{
    public class UserApplication : IUserApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppLogger _Logger;
        private readonly IConfiguration _configuration;
        private readonly IUserValidationInterface _userValidationInterface;
        //private readonly IGenereteToken _genereteToken;
        //private readonly ITokenValidationDomain _tokenValidationDomain;
        private readonly IEditUserValidationApications _editUserValidationApications;
        private readonly ITokenGenerateSegurityDomain _tokenGenerateSegurityDomain;

        public UserApplication(
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            IUserValidationInterface userValidation, 
            IEditUserValidationApications editUserValidationApications, 
            ITokenGenerateSegurityDomain tokenGenerateSegurityDomain, 
            IAppLogger Logger, 
            IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
           
            //_genereteToken = genereteToken;
            //_tokenValidationDomain = tokenValidationDomain;
            _editUserValidationApications = editUserValidationApications;
            _userValidationInterface = userValidation;
            _tokenGenerateSegurityDomain = tokenGenerateSegurityDomain;
            _Logger = Logger;
            _configuration = configuration;
        }


        //***Metodo Crea el token y lo valida contra Base de datos lista usuarios*****, 
        public async Task<BaseResponse<IEnumerable<UserResponseDto>>> ListSelectUsers(RequestGenerateTokenDto request,  List<DataItem> listHeader)
        {
            var response = new BaseResponse<IEnumerable<UserResponseDto>>();          


            string[] msgValidationRequest = new string[2];
            string token = string.Empty;

            try
            {

                //if (string.IsNullOrEmpty(token)) return await BuildResponseList();
                //if (!await _helpful.JwtIsValid(token)) return await BuildResponseList();

                string _token = token.Replace(Constants.Bearer, string.Empty);

                ////01- Generate Token***
                //RequestGenerateToken requestToken = new RequestGenerateToken();
                //var GenToken = await _genereteToken.AccesToken(requestToken);



                ////02.- If Token exists
                //token = listHeader.Find(delegate (DataItem item) { return item.Name == "token"; }).Value;

                //****Token validate ******
                //string messagetokenvalidate = await _tokenValidationDomain.TokenValidate(listHeader, request.Username, request.Password);
                //if (messagetokenvalidate.Equals(Constants.OK))
                //{
                //    //BaseResponse<UserResponseDto> errorMessage = new BaseResponse<UserResponseDto>
                //    //{
                //    //    Code = "401",
                //    //    Message = "Ocurrio un error",
                //    //    MessageUser = "Token Expirado",
                //    //    MessageUserEng = "Expire Token",
                //    //    Response = null,

                //    //};
                //    response.StatusCode = Constants.StatusCode.Code401;
                //    response.Code = "401";
                //    response.Message = "Ocurrio un error";
                //    response.MessageUser = "Token Expirado";
                //    response.Response = null;
                //    return response;
                //}



                var users = await _unitOfWork.User.GetAllAsync();

                if (users is not null)
                {
                    response.StatusCode = Constants.StatusCode.Code200;
                    response.Code = Constants.StatusCode.Code200.ToString();
                    response.Message = Constants.Mensaje.Aceptado;
                  
                    response.Response = _mapper.Map<IEnumerable<UserResponseDto>>(users);
                }
                else
                {
                    response.StatusCode = Constants.StatusCode.Code204;
                    response.Code = Constants.StatusCode.Code204.ToString();
                    response.Message = Constants.Mensaje.NoContent;
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = Constants.StatusCode.Code500;
                response.Code = Constants.StatusCode.Code500.ToString();
                response.Message = Constants.Mensaje.Exception + " " + ex.Message;
            }

            return response;
        }

        //**** Consulta User por ID ****
        public async Task<BaseResponse<UserResponseDto>> UserById(int id)
        {
            var response = new BaseResponse<UserResponseDto>();

            try
            {

                var user = await _unitOfWork.User.GetByIdAsync(id);

                if (user is not null)
                {
                    response.StatusCode= Constants.StatusCode.Code200;
                    response.Code = Constants.StatusCode.Code200.ToString();
                    response.Message = Constants.Mensaje.Aceptado;
                    response.Response = _mapper.Map<UserResponseDto>(user);
                }
                else
                {
                    response.StatusCode = Constants.StatusCode.Code204;
                    response.Code = Constants.StatusCode.Code204.ToString();
                    response.Message = Constants.Mensaje.NoContent;
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = Constants.StatusCode.Code500;
                response.Code = Constants.StatusCode.Code500.ToString();
                response.Message = Constants.Mensaje.Exception + "" + ex.Message;
            }

            return response;
        }
        //****Register***//
        public async Task<BaseResponse<bool>> Register(UserRequestCreate requestDto)
        {
            var response = new BaseResponse<bool>();

            //01- Generate Token***
            //RequestGenerateToken requestToken = new RequestGenerateToken();
            //var GenToken = await _genereteToken.AccesToken(requestToken);

           

            var requestValidation = await _userValidationInterface.ValidateUserCreate(requestDto);
            if (!requestValidation.Validate)
            {
                response.Code = requestValidation.Code;
                response.Message = requestValidation.Message;
                return response;
            }

            try
            {
                var user = _mapper.Map<User>(requestDto);
                //Encriptando password
                user.Password = Utilities.GenerateMd5(user.Password);
                //enncriptado de llave publica
                user.PublicKey = Utilities.GenerateMd5(user.PublicKey);
                //Roles
                user.RoleId = 1;
                response.Response = await _unitOfWork.User.RegisterAsync(user);

                if (response.Response)
                {
                    response.StatusCode = Constants.StatusCode.Code200;
                    response.Code = Constants.StatusCode.Code200.ToString();
                    response.Message = Constants.Mensaje.Aceptado;
                }
                else
                {
                    response.StatusCode = Constants.StatusCode.Code204;
                    response.Code = Constants.StatusCode.Code204.ToString();
                    response.Message = Constants.Mensaje.NoContent;
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = Constants.StatusCode.Code500;
                response.Code = Constants.StatusCode.Code500.ToString();
                response.Message = Constants.Mensaje.Exception + "" + ex.Message;
            }

            return response;
        }
        //***Edit User ****/
        public async Task<BaseResponse<bool>> Edit(int id, UserRequestEdit requestDto)
        {
            var response = new BaseResponse<bool>();

            try
            {
                //Validaciòn Campos del Request

                var requestValidation = await _editUserValidationApications.ValidateUserCreate(requestDto);
                if (!requestValidation.Validate)
                {
                    response.Code = requestValidation.Code;
                    response.Message = requestValidation.Message;
                    return response;
                }

                var userEdit = await UserById(id);

                if (userEdit is null)
                {
                    response.Code = Constants.StatusCode.Code204.ToString();
                    response.Message = Constants.Mensaje.NoContent;
                    return response;
                }

                var user = _mapper.Map<User>(requestDto);
                user.Id = id;
                user.Password = Utilities.GenerateMd5(user.Password);
                user.PublicKey = Utilities.GenerateMd5(user.PublicKey);
                user.RoleId = 1;
                response.Response = await _unitOfWork.User.EditAsync(user);

                if (response.Response)
                {
                    response.Code = Constants.StatusCode.Code200.ToString();
                    response.Message = Constants.Mensaje.Aceptado;
                }
                else
                {
                    response.Code = Constants.StatusCode.Code204.ToString();
                    response.Message = Constants.Mensaje.NoContent;
                }
            }
            catch (Exception ex)
            {
                response.Code = Constants.StatusCode.Code500.ToString();
                response.Message = Constants.Mensaje.Exception + "" + ex.Message;
            }

            return response;
        }
        //***Delete User ***//
        public async Task<BaseResponse<bool>> Remove(int id)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var userEdit = await UserById(id);

                if (userEdit.Response is null)
                {
                    response.Code = Constants.StatusCode.Code204.ToString();
                    response.Message = Constants.Mensaje.NoContent;
                    return response;
                }

                response.Response = await _unitOfWork.User.RemoveAsync(id);

                if (response.Response)
                {
                    response.Code = Constants.StatusCode.Code200.ToString();
                    response.Message = Constants.Mensaje.Aceptado;
                }
                else
                {
                    response.Code = Constants.StatusCode.Code204.ToString();
                    response.Message = Constants.Mensaje.NoContent;
                }
            }
            catch (Exception ex)
            {
                response.Code = Constants.StatusCode.Code500.ToString();
                response.Message = Constants.Mensaje.Exception + "" + ex.Message;
            }

            return response;
        }
        public async Task<BaseResponse<ResponseTokenDto>> AccountByUserName(LoginRequestDto request)
        {
           

            var customerUserName = request.Username.Trim();
            var customerPasswordMd5 = Utilities.GenerateMd5(request.Password.Trim());

            var response = new BaseResponse<ResponseTokenDto>();

            try
            {

                var user = await _unitOfWork.User.AccountByUserName(customerUserName);

                if (user is not null)
                {
                    if (user.State.Equals((int)StateTypes.Inactive))
                    {
                        response.Code = Constants.StatusCode.Code401.ToString();
                        response.StatusCode = Constants.StatusCode.Code401;
                        response.Message = Constants.Mensaje.UserInactive;
                    }
                    else
                    {
                        if (!user.Password.Equals(customerPasswordMd5))
                        {
                            response.Code = Constants.StatusCode.Code401.ToString();
                            response.StatusCode = Constants.StatusCode.Code401;
                            response.Message = Constants.Mensaje.ContraseniaError;
                        }
                        else
                        {
                            //Retornando el token
                            RequestGenerateTokenDto requestGenerateToken = new RequestGenerateTokenDto();

                            requestGenerateToken.UserId = user.Id;
                            requestGenerateToken.Username = user.UserName;
                            requestGenerateToken.Password = user.Password;
                            requestGenerateToken.KeyPublic = user.PublicKey;

                            var token = GenerateToken(requestGenerateToken);

                            if (token.Result.Message.Equals("Ok"))
                            response.Code = Constants.StatusCode.Code200.ToString();
                            response.StatusCode = Constants.StatusCode.Code200;
                            response.Message = Constants.Mensaje.Aceptado;
                            response.Response = token.Result.Data;
                            //response.Response = _mapper.Map<UserResponseDto>(user);
                        }
                    }

                }
                else
                {
                    response.Code = Constants.StatusCode.Code204.ToString();
                    response.StatusCode = Constants.StatusCode.Code204;
                    response.Message = Constants.Mensaje.NoContent;
                }
            }
            catch (Exception ex)
            {
                response.Code = Constants.StatusCode.Code500.ToString();
                response.StatusCode = Constants.StatusCode.Code500;
                response.Message = Constants.Mensaje.Exception + "" + ex.Message;
            }

            return response;
        }
        public async Task<BaseResponse<BaseEntityResponse<UserResponseDto>>> ListUsersFilters(BaseFiltersRequest filters, List<DataItem> listHeader)
        {
            var response = new BaseResponse<BaseEntityResponse<UserResponseDto>>();

            try
            {
                RequestValidateDto requestValidateDto = new RequestValidateDto();

                var token = listHeader.Find(delegate (DataItem item) { return item.Name == "token"; }).Value;

                if (token == null)
                {
                    response.StatusCode = Constants.StatusCode.Code401;
                    response.Code = Constants.StatusCode.Code401.ToString();
                    response.Message = Constants.Mensaje.Unauthorized;
                    return response;
                }

                requestValidateDto.Token = token.Replace(Constants.Bearer, string.Empty).Trim();

                //Validacion de Token
                var responseToken = await ValidateToken(requestValidateDto);

                if (!responseToken.Data.Validate)
                {
                    response.StatusCode = Constants.StatusCode.Code401;
                    response.Code = Constants.StatusCode.Code401.ToString();
                    response.Message = Constants.Mensaje.Unauthorized;
                    return response;
                }
                
                var result = await _unitOfWork.User.ListUsersFilters(filters);

                if (result is not null) 
                {
                    response.StatusCode = Constants.StatusCode.Code200;
                    response.Code = Constants.StatusCode.Code200.ToString();
                    response.Message = Constants.Mensaje.Aceptado;
                    response.Response = _mapper.Map<BaseEntityResponse<UserResponseDto>>(result);
                    //_mapper.Map<IEnumerable<UserResponseDto>>(users);
                }
                else
                {
                    response.StatusCode = Constants.StatusCode.Code204;
                    response.Code = Constants.StatusCode.Code204.ToString();
                    response.Message = Constants.Mensaje.NoContent;
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = Constants.StatusCode.Code500;
                response.Code = Constants.StatusCode.Code500.ToString();
                response.Message = Constants.Mensaje.Exception + " " + ex.Message;
            }

            return response;
        }
        public async Task<BaseResponseDto<ResponseTokenDto, BaseRequestDto>> GenerateToken(RequestGenerateTokenDto requestPublico)
        {
            BaseResponseDto<ResponseTokenDto, BaseRequestDto> response = new BaseResponseDto<ResponseTokenDto, BaseRequestDto>();
            TokenSession tokenSession = new TokenSession();
            try
            {
                if (requestPublico == null)
                {
                    response.Message = "entity cannot be null or empty.";
                    return response;
                }

                _Logger.LogInfo("Inicio Generacion token");
                Guid TokenId = Guid.NewGuid();
                GenerateJWT generateJWT = new GenerateJWT();
                int timeToExpiration = _configuration.GetValue<int>("ExpirationTimeJwtMinutes");
                string tokencreado = await generateJWT.GenerateAccessToken(requestPublico, TokenId, timeToExpiration);

                response.Message = "Ok";
                response.Data = new ResponseTokenDto { Token = tokencreado };

                return response;
            }

            catch (Exception e)
            {
                _Logger.LogError(e, "GenerateToken");
                response.Message = "An error occurred.";
                return response;
            }
        }
        public async Task<BaseResponseDto<ResponseValidateToken, BaseRequestDto>> ValidateToken(RequestValidateDto requestValidateDto)
        {
            BaseResponseDto<ResponseValidateToken, BaseRequestDto> response = new BaseResponseDto<ResponseValidateToken, BaseRequestDto>();

            try
            {
                ValidateJWT validateJwt = new ValidateJWT();
                response.Message = validateJwt.Validate(requestValidateDto.Token);

                //Validacion
                if (response.Message.Equals("OK"))
                {
                    var TokenId = validateJwt.GetClaimToken(requestValidateDto.Token, "TokenId");
                    var UserId = validateJwt.GetClaimToken(requestValidateDto.Token, "UserId");
                    var UserName = validateJwt.GetClaimToken(requestValidateDto.Token, "UserName");

                    //var tokenSession = await _tokenSessionDomain.Select(TokenId);
                    //if (string.IsNullOrEmpty(tokenSession.Token)) response.Message = "token not found.";
                    
                    response.Message = "Token Validado OK";
                    response.Data = new ResponseValidateToken { Validate = true };

                }
                if (response.Message.Equals(null))
                {
                    response.Message = "Ocurrio un error, no se pudo validar el token";
                    response.Data = new ResponseValidateToken { Validate = false };
                }

            }
            catch (Exception e)
            {
               
                response.Message = "An error occurred.";
                response.Data = new ResponseValidateToken { Validate = false };
                return response;
            }
            return response;
        }
    }
}
