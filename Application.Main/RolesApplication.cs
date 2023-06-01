using Application.DTO.Base;
using Application.DTO.Request;
using Application.DTO.Response;
using Application.Interface;
using AutoMapper;
using Common;
using Domain.Entity.V1;
using Infraestructure.Commons.Base.Request;
using Infraestructure.Interface.Patterns;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Main
{
    public class RolesApplication : IRolesApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RolesApplication(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseResponse<IEnumerable<RolesResponseDto>>> ListSelectRolesFilter(BaseFiltersRequest filters)
        {
            var response = new BaseResponse<IEnumerable<RolesResponseDto>>();

            try
            {
                var result = await _unitOfWork.Role.ListRolesFilters(filters);

                if (result is not null)
                {
                    response.Code = Constants.StatusCode.Code200.ToString();
                    response.Message = Constants.Mensaje.Aceptado;
                    response.Response = _mapper.Map<IEnumerable<RolesResponseDto>>(result);
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
                response.Message = Constants.Mensaje.Exception + " " + ex.Message;
            }

            return response;
        }
        public async Task<BaseResponse<IEnumerable<RolesResponseDto>>> ListSelectRoles()
        {
            var response = new BaseResponse<IEnumerable<RolesResponseDto>>();

            try
            {
                var result = await _unitOfWork.Role.GetAllAsync();

                if (result is not null)
                {
                    response.Code = Constants.StatusCode.Code200.ToString();
                    response.Message = Constants.Mensaje.Aceptado;
                    response.Response = _mapper.Map<IEnumerable<RolesResponseDto>>(result);
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
                response.Message = Constants.Mensaje.Exception + " " + ex.Message;
            }

            return response;
        }
        public async Task<BaseResponse<RolesResponseDto>> RolesById(int id)
        {
            var response = new BaseResponse<RolesResponseDto>();

            try
            {
                var result = await _unitOfWork.Role.GetByIdAsync(id);

                if (result is not null)
                {
                    response.Code = Constants.StatusCode.Code200.ToString();
                    response.Message = Constants.Mensaje.Aceptado;
                    response.Response = _mapper.Map<RolesResponseDto>(result);
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
        public async Task<BaseResponse<bool>> Register(RolesRequestCreateDto requestDto)
        {
            var response = new BaseResponse<bool>();

            

            try
            {
                //var validationResult = await _validationRules.ValidateAsync(requestDto);

                //if (!validationResult.IsValid)
                //{
                //    response.IsSuccess = false;
                //    response.Message = ReplyMessage.MESSAGE_VALIDATE;
                //    response.Errors = validationResult.Errors;
                //    return response;
                //}

                var role = _mapper.Map<Role>(requestDto);
                //Encriptando
                response.Response = await _unitOfWork.Role.RegisterAsync(role);

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
        public async Task<BaseResponse<bool>> Edit(int id, RolesRequestEditDto requestDto)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var roleEdit = await RolesById(id);

                if (roleEdit.Response is null)
                {
                    response.Code = Constants.StatusCode.Code204.ToString();
                    response.Message = Constants.Mensaje.NoContent;
                    return response;
                }

                var role = _mapper.Map<Role>(requestDto);

                response.Response = await _unitOfWork.Role.EditAsync(role);

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
        public async Task<BaseResponse<bool>> Remove(int id)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var roleEdit = await RolesById(id);

                if (roleEdit.Response is null)
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

        
    }
}
