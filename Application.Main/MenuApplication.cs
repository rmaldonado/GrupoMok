using Application.DTO.Base;
using Application.DTO.Request;
using Application.DTO.Response;
using Application.Interface;
using AutoMapper;
using Common;
using Domain.Entity.V1;
using Domain.Interface.ValidationInterface.User;
using Infraestructure.Interface.Patterns;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Main {
    public class MenuApplication : IMenuApplication {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEditMenuValidationAplications _editMenuValidationAplications;
        private readonly IMenuValidationAplications _menuValidationAplications;

        public MenuApplication(IUnitOfWork unitOfWork, IMapper mapper, IEditMenuValidationAplications editMenuValidationAplications, IMenuValidationAplications menuValidationAplications) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _editMenuValidationAplications = editMenuValidationAplications;
            _menuValidationAplications = menuValidationAplications;

        }

        public async Task<BaseResponse<IEnumerable<MenuResponseDto>>> ListSelectMenu() {

            var response = new BaseResponse<IEnumerable<MenuResponseDto>>();

            try {
                var menus = await _unitOfWork.Menu.GetAllAsync();

                if (menus is not null) {
                    response.Code = Constants.StatusCode.Code200.ToString();
                    response.Message = Constants.Mensaje.Aceptado;
                    response.Response = _mapper.Map<IEnumerable<MenuResponseDto>>(menus);
                }
                else {
                    response.Code = Constants.StatusCode.Code204.ToString();
                    response.Message = Constants.Mensaje.NoContent;
                }
            }
            catch (Exception ex) {
                response.Code = Constants.StatusCode.Code500.ToString();
                response.Message = Constants.Mensaje.Exception+' '+ex.Message;
            }

            return response;
        }

        public async Task<BaseResponse<MenuResponseDto>> MenuById(int id) {

            var response = new BaseResponse<MenuResponseDto>();

            try {
                var menu = await _unitOfWork.Menu.GetByIdAsync(id);

                if (menu is not null) {
                    response.Code = Constants.StatusCode.Code200.ToString();
                    response.Message = Constants.Mensaje.Aceptado;
                    response.Response = _mapper.Map<MenuResponseDto>(menu);
                }
                else {
                    response.Code = Constants.StatusCode.Code204.ToString();
                    response.Message = Constants.Mensaje.NoContent;
                }
            }
            catch (Exception ex) {
                response.Code = Constants.StatusCode.Code500.ToString();
                response.Message = Constants.Mensaje.Exception + "" + ex.Message;
            }

            return response;
        }

        public async Task<BaseResponse<bool>> Register(MenuRequestCreateDto requestDto) {
            var response = new BaseResponse<bool>();
            try {
              
                var requestValidation = await _menuValidationAplications.ValidateMenu(requestDto);
                if (!requestValidation.Validate)
                {
                    response.Code = requestValidation.Code;
                    response.Message = requestValidation.Message;
                    return response;
                }

                var menu = _mapper.Map<Menu>(requestDto);
                response.Response = await _unitOfWork.Menu.RegisterAsync(menu);

                if (response.Response) {
                    response.Code = Constants.StatusCode.Code200.ToString();
                    response.Message = Constants.Mensaje.Aceptado;
                }
                else {
                    response.Code = Constants.StatusCode.Code204.ToString();
                    response.Message = Constants.Mensaje.NoContent;
                }
            }
            catch (Exception ex) {
                response.Code = Constants.StatusCode.Code500.ToString();
                response.Message = Constants.Mensaje.Exception + "" + ex.Message;
            }

            return response;
        }
        public async Task<BaseResponse<bool>> Edit(int id, MenuRequestEditDto requestDto) {
            var response = new BaseResponse<bool>();

            try {

                var requestValidation = await _editMenuValidationAplications.ValidateMenuEdit(requestDto);
                if (!requestValidation.Validate)
                {
                    response.Code = requestValidation.Code;
                    response.Message = requestValidation.Message;
                    return response;
                }


                var companyEdit = await MenuById(id);

                if (companyEdit.Response is null) {
                    response.Code = Constants.StatusCode.Code204.ToString();
                    response.Message = Constants.Mensaje.NoContent;
                    return response;
                }

                var menu = _mapper.Map<Menu>(requestDto);
                menu.Id = id;
                response.Response = await _unitOfWork.Menu.EditAsync(menu);

                if (response.Response) {
                    response.Code = Constants.StatusCode.Code200.ToString();
                    response.Message = Constants.Mensaje.Aceptado;
                }
                else {
                    response.Code = Constants.StatusCode.Code204.ToString();
                    response.Message = Constants.Mensaje.NoContent;
                }
            }
            catch (Exception ex) {
                response.Code = Constants.StatusCode.Code500.ToString();
                response.Message = Constants.Mensaje.Exception + "" + ex.Message;
            }

            return response;
        }
        public async Task<BaseResponse<bool>> Remove(int id) {
            var response = new BaseResponse<bool>();

            try {
                var userEdit = await MenuById(id);

                if (userEdit.Response is null) {
                    response.Code = Constants.StatusCode.Code204.ToString();
                    response.Message = Constants.Mensaje.NoContent;
                    return response;
                }

                response.Response = await _unitOfWork.Menu.RemoveAsync(id);

                if (response.Response) {
                    response.Code = Constants.StatusCode.Code200.ToString();
                    response.Message = Constants.Mensaje.Aceptado;
                }
                else {
                    response.Code = Constants.StatusCode.Code204.ToString();
                    response.Message = Constants.Mensaje.NoContent;
                }
            }
            catch (Exception ex) {
                response.Code = Constants.StatusCode.Code500.ToString();
                response.Message = Constants.Mensaje.Exception + "" + ex.Message;
            }

            return response;
        }
    }
}
